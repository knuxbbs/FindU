using System;

namespace FindU
{
	public class Estudante
	{
		public int Id { get; set; }

		#region [ Dados de estudante ]

		public string Matricula { get; set; }
		public Curso Curso { get; set; }
		public int CursoId { get; set; }
		public int AnoIngresso { get; set; }
		public bool Formado { get; set; }

		#endregion

		#region [ Dados pessoais ]

		public string Nome { get; set; }
		public string CaminhoFoto { get; set; }
		public DateTime DataNascimento { get; set; }
		public string Sobre { get; set; }
		public OrientacaoSexual OrientacaoSexual { get; set; }
		public int OrientacaoSexualId { get; set; }
		public Religiao Religiao { get; set; }
		public int ReligiaoId { get; set; }
		public OrientacaoPolitica OrientacaoPolitica { get; set; }
		public int OrientacaoPoliticaId { get; set; }

		public string Localizacao { get; set; }
		//public bool DeGatos { get; set; }
		//public bool DeCachorros { get; set; }

		#endregion
	}
}
