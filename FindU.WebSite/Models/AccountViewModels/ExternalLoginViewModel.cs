using FindU.Application.Components;
using FindU.Application.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FindU.WebSite.Models.AccountViewModels
{
	public class ExternalLoginViewModel
	{
		[Required(ErrorMessage = "Foto é obrigatória.")]
		public string CaminhoFoto { get; set; }

		[Required(ErrorMessage = "Gênero é obrigatório.")]
		public int GeneroId { get; set; }

		public IEnumerable<GeneroViewModel> Generos = new[]
		{
			new GeneroViewModel{Id = 1, Descricao = "Masculino"},
			new GeneroViewModel{Id = 2, Descricao = "Feminino"}
		};

		[Required(ErrorMessage = "Nome é obrigatório.")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "E-mail é obrigatório.")]
		[EmailAddress]
		[Display(Name = "E-mail")]
		public string Email { get; set; }

		[Phone]
		[Display(Name = "Telefone")]
		public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "Data de nascimento é obrigatória.")]
		[DataType(DataType.Date)]
		[Display(Name = "Data de nascimento")]
		public DateTime DataNascimento { get; set; }

		[Required(ErrorMessage = "Curso é obrigatório.")]
		[Display(Name = "Curso")]
		public int CursoId { get; set; }

		public SelectList Cursos { get; set; }

		[Required(ErrorMessage = "Número de matrícula é obrigatório.")]
		[MinLength(9, ErrorMessage = "Matrícula inválida.")]
		[Remote("ValidarMatricula", "Account", AdditionalFields = nameof(CursoId))]
		[Display(Name = "Matrícula")]
		public string Matricula { get; set; }

		[HiddenInput]
		public int AnoIngresso { get; set; }

		[HiddenInput]
		public bool Formado { get; set; } = false;

		[Required(ErrorMessage = "Descrição é obrigatória.")]
		[Display(Name = "Quem sou eu")]
		public string Sobre { get; set; }

		public int ReligiaoId { get; set; }

		public SelectList Religioes { get; set; }

		[Display(Name = "Orientação política")]
		public int OrientacaoPoliticaId { get; set; }

		public SelectList OrientacoesPoliticas { get; set; }

		[Display(Name = "Bebo")]
		public int TipoDeConsumoBebidaId { get; set; }

		public SelectList TiposDeConsumoBebida { get; set; }

		public CheckBoxListItem[] TiposDeAtracao { get; set; }

		[Display(Name = "Interessado em")]
		[MinChecked(1, ErrorMessage = "É preciso selecionar pelo menos um interesse.")]
		public CheckBoxListItem[] GenerosInteresse { get; set; }

		[HiddenInput]
		public string Localizacao { get; set; }
	}

	public class GeneroViewModel
	{
		public int Id { get; set; }
		public string Descricao { get; set; }
	}
}
