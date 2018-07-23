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
	public class SupacDataImporter
	{
		public bool ValidarMatricula(string matricula, Curso curso)
		{
			var pdfStream = new MemoryStream(new WebClient().DownloadData(
				string.Format("http://matricula.ufba.br/{0}_escalonamento.pdf", curso.CodigoSupac)));

			var estudantes = new List<string>();

			using (var pdfReader = new PdfReader(pdfStream))
			{
				var pdfDocument = new PdfDocument(pdfReader);

				for (var pageNum = 1; pageNum <= pdfDocument.GetNumberOfPages(); pageNum++)
				{
					var currentText = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(pageNum));
					var startIndex = currentText.IndexOf("1ª Etapa Alocação", StringComparison.InvariantCulture) + "1ª Etapa Alocação".Length;
					var index = currentText.IndexOf("Critério de Escalonamento", StringComparison.InvariantCulture);

					currentText = currentText.Substring(startIndex, index - startIndex).Trim();
					currentText =
						Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8,
							Encoding.Default.GetBytes(currentText)));

					estudantes.AddRange(Regex.Split(currentText, @"\n(\d+)"));

					estudantes = estudantes.Where(x => !int.TryParse(x, out _) && !string.IsNullOrEmpty(x)).ToList();
				}
			}

			var listaEstudanteDto = new List<EstudanteDto>();
			var sobras = new string[] { };

			for (var i = 0; i < estudantes.Count; i++)
			{
				string[] estudanteSplit;
				int lastCharIndex, escore;
				bool existeEscore;

				var estudante = estudantes[i];
				var matriculaIndex = estudante.IndexOf("-", StringComparison.InvariantCulture);

				if (estudante.Contains('\n'))
				{
					var index = estudante.IndexOf('\n');
					sobras = estudante.Substring(index).Trim('\n').Split(' ');
					estudante = estudante.Substring(0, index);
				}

				if (i > 0 && estudantes[i - 1].Contains('\n'))
				{
					estudanteSplit = estudante.Split();
					lastCharIndex = estudante.IndexOf(estudanteSplit[estudanteSplit.Length - 6], StringComparison.Ordinal);

					//Verifica se existe escore registrado
					existeEscore = int.TryParse(sobras[2], out escore);

					if (!existeEscore)
					{
						var tempList = sobras.ToList();
						tempList.Insert(2, string.Empty);
						sobras = tempList.ToArray();
					}

					listaEstudanteDto.Add(new EstudanteDto
					{
						Matricula = estudante.Substring(0, matriculaIndex).Trim(),
						Nome = estudante.Substring(matriculaIndex + 1, lastCharIndex - matriculaIndex - 1).Trim().ToUpper(),
						Sa = sobras[0],
						Concluinte = estudanteSplit[estudanteSplit.Length - 6],
						Orient = sobras[1],
						Escore = escore,
						Equiv = sobras[3],
						Freq = int.Parse(estudanteSplit[estudanteSplit.Length - 5]),
						Trancamentos = int.Parse(estudanteSplit[estudanteSplit.Length - 4]),
						Ingresso = sobras[4],
						Turma = int.Parse(estudanteSplit[estudanteSplit.Length - 3]),
						Disciplinas = int.Parse(estudanteSplit[estudanteSplit.Length - 2]),
						Atendidas = int.Parse(estudanteSplit[estudanteSplit.Length - 1])
					});

					continue;
				}

				estudanteSplit = estudante.Split();
				lastCharIndex = estudante.IndexOf("-", matriculaIndex + 1, StringComparison.Ordinal);

				//Verifica se existe escore registrado
				existeEscore = int.TryParse(estudanteSplit[estudanteSplit.Length - 8], out escore);

				if (!existeEscore)
				{
					var tempList = estudanteSplit.ToList();
					tempList.Insert(estudanteSplit.Length - 6, string.Empty);
					estudanteSplit = tempList.ToArray();
				}

				listaEstudanteDto.Add(new EstudanteDto
				{
					Matricula = estudante.Substring(0, matriculaIndex).Trim(),
					Nome = estudante.Substring(matriculaIndex + 1, lastCharIndex - matriculaIndex - 1).Trim().ToUpper(),
					Sa = estudanteSplit[estudanteSplit.Length - 11],
					Concluinte = estudanteSplit[estudanteSplit.Length - 10],
					Orient = estudanteSplit[estudanteSplit.Length - 9],
					Escore = escore,
					Equiv = estudanteSplit[estudanteSplit.Length - 7],
					Freq = int.Parse(estudanteSplit[estudanteSplit.Length - 6]),
					Trancamentos = int.Parse(estudanteSplit[estudanteSplit.Length - 5]),
					Ingresso = estudanteSplit[estudanteSplit.Length - 4],
					Turma = int.Parse(estudanteSplit[estudanteSplit.Length - 3]),
					Disciplinas = int.Parse(estudanteSplit[estudanteSplit.Length - 2]),
					Atendidas = int.Parse(estudanteSplit[estudanteSplit.Length - 1])
				});
			}

			return listaEstudanteDto.Any(x => x.Matricula == matricula);
		}

		public class EstudanteDto
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
