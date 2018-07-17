using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;

namespace FindU.Application
{
	public class Class1
	{
		public bool VerificarMatricula(string matricula, Curso curso)
		{
			//var pdfStream = File.OpenRead("C:\\Users\\ba7308\\Downloads\\196_escalonamento.pdf");

			var pdfStream = new MemoryStream(new WebClient().DownloadData(
				string.Format("http://matricula.ufba.br/{0}_escalonamento.pdf", curso.CodigoSupac)));

			var alunos = new List<string>();

			using (var pdfReader = new PdfReader(pdfStream))
			{
				var pdfDocument = new PdfDocument(pdfReader);

				for (var pageNum = 1; pageNum <= pdfDocument.GetNumberOfPages(); pageNum++)
				{
					//var obj = pdfDocument.GetPage(pageNum).GetPdfObject();

					//var parser = new PdfDocumentContentParser(pdfDocument);
					//var textFromPage =
					//	Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, pdfDocument.GetPage(pageNum)));
					var currentText = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(pageNum));
					var startIndex = currentText.IndexOf("1ª Etapa Alocação", StringComparison.InvariantCulture) + "1ª Etapa Alocação".Length;
					var index = currentText.IndexOf("Critério de Escalonamento", StringComparison.InvariantCulture);

					currentText = currentText.Substring(startIndex, index - startIndex).Trim();
					currentText =
						Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8,
							Encoding.Default.GetBytes(currentText)));

					alunos.AddRange(Regex.Split(currentText, @"\n(\d+)"));

					alunos = alunos.Where(x => !int.TryParse(x, out _) && !string.IsNullOrEmpty(x)).ToList();
				}
			}

			var listaAlunoDto = new List<AlunoDto>();
			var sobras = new string[] { };

			for (var i = 0; i < alunos.Count; i++)
			{
				string[] alunoSplit;
				int lastCharIndex, escore;
				bool existeEscore;

				var aluno = alunos[i];
				var matriculaIndex = aluno.IndexOf("-", StringComparison.InvariantCulture);

				if (aluno.Contains('\n'))
				{
					var index = aluno.IndexOf('\n');
					sobras = aluno.Substring(index).Trim('\n').Split(' ');
					aluno = aluno.Substring(0, index);
				}

				if (i > 0 && alunos[i - 1].Contains('\n'))
				{
					alunoSplit = aluno.Split();
					lastCharIndex = aluno.IndexOf(alunoSplit[alunoSplit.Length - 6], StringComparison.Ordinal);

					//Verifica se existe escore registrado
					existeEscore = int.TryParse(sobras[2], out escore);

					if (!existeEscore)
					{
						var tempList = sobras.ToList();
						tempList.Insert(2, string.Empty);
						sobras = tempList.ToArray();
					}

					listaAlunoDto.Add(new AlunoDto
					{
						Matricula = aluno.Substring(0, matriculaIndex).Trim(),
						Nome = aluno.Substring(matriculaIndex + 1, lastCharIndex - matriculaIndex - 1).Trim().ToUpper(),
						Sa = sobras[0],
						Concluinte = alunoSplit[alunoSplit.Length - 6],
						Orient = sobras[1],
						Escore = escore,
						Equiv = sobras[3],
						Freq = int.Parse(alunoSplit[alunoSplit.Length - 5]),
						Trancamentos = int.Parse(alunoSplit[alunoSplit.Length - 4]),
						Ingresso = sobras[4],
						Turma = int.Parse(alunoSplit[alunoSplit.Length - 3]),
						Disciplinas = int.Parse(alunoSplit[alunoSplit.Length - 2]),
						Atendidas = int.Parse(alunoSplit[alunoSplit.Length - 1])
					});

					continue;
				}

				alunoSplit = aluno.Split();
				lastCharIndex = aluno.IndexOf("-", matriculaIndex + 1, StringComparison.Ordinal);

				//Verifica se existe escore registrado
				existeEscore = int.TryParse(alunoSplit[alunoSplit.Length - 8], out escore);

				if (!existeEscore)
				{
					var tempList = alunoSplit.ToList();
					tempList.Insert(alunoSplit.Length - 6, string.Empty);
					alunoSplit = tempList.ToArray();
				}

				listaAlunoDto.Add(new AlunoDto
				{
					Matricula = aluno.Substring(0, matriculaIndex).Trim(),
					Nome = aluno.Substring(matriculaIndex + 1, lastCharIndex - matriculaIndex - 1).Trim().ToUpper(),
					Sa = alunoSplit[alunoSplit.Length - 11],
					Concluinte = alunoSplit[alunoSplit.Length - 10],
					Orient = alunoSplit[alunoSplit.Length - 9],
					Escore = escore,
					Equiv = alunoSplit[alunoSplit.Length - 7],
					Freq = int.Parse(alunoSplit[alunoSplit.Length - 6]),
					Trancamentos = int.Parse(alunoSplit[alunoSplit.Length - 5]),
					Ingresso = alunoSplit[alunoSplit.Length - 4],
					Turma = int.Parse(alunoSplit[alunoSplit.Length - 3]),
					Disciplinas = int.Parse(alunoSplit[alunoSplit.Length - 2]),
					Atendidas = int.Parse(alunoSplit[alunoSplit.Length - 1])
				});
			}

			return listaAlunoDto.Any(x => x.Matricula == matricula);
		}

		public class AlunoDto
		{
			public string Matricula { get; set; }
			public string Nome { get; set; }
			public string Sa { get; set; }
			public string Concluinte { get; set; }
			public string Orient { get; set; }
			public int Escore { get; set; }
			public string Equiv { get; set; }
			public int Freq { get; set; }
			public int Trancamentos { get; set; }
			public string Ingresso { get; set; }
			public int Turma { get; set; }
			public int Disciplinas { get; set; }
			public int Atendidas { get; set; }
		}
	}
}
