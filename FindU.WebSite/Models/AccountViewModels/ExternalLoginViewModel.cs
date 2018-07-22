using FindU.WebSite.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FindU.WebSite.Models.AccountViewModels
{
	public class ExternalLoginViewModel
	{
		[Required]
		public string CaminhoFoto { get; set; }

		[Required]
		public int GeneroId { get; set; }

		public IEnumerable<GeneroViewModel> Generos = new[]
		{
			new GeneroViewModel{Id = 1, Descricao = "Masculino"},
			new GeneroViewModel{Id = 2, Descricao = "Feminino"}
		};

		[Required]
		public string Nome { get; set; }

		[Required]
		[EmailAddress]
		[Display(Name = "E-mail")]
		public string Email { get; set; }

		[Phone]
		[Display(Name = "Telefone")]
		public string PhoneNumber { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[Display(Name = "Data de nascimento")]
		public DateTime DataNascimento { get; set; }

		[Required(ErrorMessage = "Número de matrícula é obrigatório.")]
		[Remote("ValidarMatricula", "Account")]
		public string Matricula { get; set; }

		[Display(Name = "Curso")]
		[Required(ErrorMessage = "Curso é obrigatório.")]
		public int CursoId { get; set; }

		public SelectList Cursos { get; set; }

		[HiddenInput]
		public int AnoIngresso { get; set; }

		[HiddenInput]
		public bool Formado { get; set; } = false;

		[Required]
		public string Sobre { get; set; }

		public int ReligiaoId { get; set; }

		public SelectList Religioes { get; set; }

		public int OrientacaoPoliticaId { get; set; }

		public SelectList OrientacoesPoliticas { get; set; }

		[Required]
		public IEnumerable<int> InteressadoEm { get; set; }

		public CheckBoxListItem[] GenerosInteresse = new[]
		{
			new CheckBoxListItem{Id = 1, Text = "Homens"},
			new CheckBoxListItem{Id = 2, Text = "Mulheres"},
		};

		[HiddenInput]
		public string Localizacao { get; set; }
	}

	public class GeneroViewModel
	{
		public int Id { get; set; }
		public string Descricao { get; set; }
	}
}
