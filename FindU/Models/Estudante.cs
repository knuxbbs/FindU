using System;
using System.Collections.Generic;
using FindU.Models.Identity;
using FindU.Models.Joins;

namespace FindU.Models
{
	public class Estudante
	{
		public int Id { get; set; }

		#region [ Dados de estudante ]

		public string Matricula { get; set; }
		public virtual Curso Curso { get; set; }
		public int CursoId { get; set; }
		public int AnoIngresso { get; set; }
		public bool Formado { get; set; }

		#endregion

		#region [ Dados pessoais ]

		public string Nome { get; set; }
		public string Sobrenome { get; set; }
		public string CaminhoFoto { get; set; }
		public DateTime DataNascimento { get; set; }
		public string Descricao { get; set; }
		public Genero Genero { get; set; }
		public OrientacaoSexual OrientacaoSexual { get; set; }
		//public int OrientacaoSexualId { get; set; }
		//public Religiao Religiao { get; set; }
		//public int ReligiaoId { get; set; }
		public virtual OrientacaoPolitica OrientacaoPolitica { get; set; }
		public int? OrientacaoPoliticaId { get; set; }
		public virtual TipoDeConsumoBebida TipoDeConsumoBebida { get; set; }
		public int? TipoDeConsumoBebidaId { get; set; }
		public virtual IEnumerable<EstudanteHasTipoDeAtracao> TiposDeAtracao { get; set; }

		public string Localizacao { get; set; }
		//public bool DeGatos { get; set; }
		//public bool DeCachorros { get; set; }

		#endregion

		public string UsuarioId { get; set; }
		public virtual User Usuario { get; set; }
	}

	public enum Genero
	{
		Masculino = 1,
		Feminino = 2
	}

	public enum OrientacaoSexual
	{
		Hetero = 1,
		Homo = 2,
		Bi = 3
	}
}
