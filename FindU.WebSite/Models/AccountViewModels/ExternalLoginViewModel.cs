using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FindU.WebSite.Models.AccountViewModels
{
	public class ExternalLoginViewModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		public string Nome { get; set; }

		[Display(Name = "Data de nascimento")]
		[DataType(DataType.Date)]
		public DateTime DataNascimento { get; set; }

		public int GeneroId { get; set; }

		public IEnumerable<GeneroViewModel> Generos = new[]
		{
			new GeneroViewModel{Id = 1, Descricao = "Masculino"},
			new GeneroViewModel{Id = 2, Descricao = "Feminino"},
			new GeneroViewModel{Id = 0, Descricao = "Não informado"}
		};

		[Display(Name = "Município")]
		public string Municipio { get; set; }

		public string PhotoUrl { get; set; }
	}

	public class GeneroViewModel
	{
		public int Id { get; set; }
		public string Descricao { get; set; }
	}
}
