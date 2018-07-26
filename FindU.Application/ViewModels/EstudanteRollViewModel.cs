using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace FindU.Application.ViewModels
{
    public class EstudanteRollViewModel
    {
	    public string CaminhoFoto { get; set; }
	    public string Nome { get; set; }
	    public int Idade { get; set; }
	    [Display(Name = "Descrição")]
		public string Descricao { get; set; }
	    [Display(Name = "Orientação política")]
		public string OrientacaoPolitica { get; set; }
	    [Display(Name = "Bebe")]
		public string TipoDeConsumoBebida { get; set; }
	    public string[] TiposDeAtracao { get; set; }
		[Display(Name = "Área")]
	    public string AreaConhecimento { get; set; }
	    [Display(Name = "Na UFBA desde")]
		public int AnoIngresso { get; set; }
	    public string UsuarioId { get; set; }
		public List<string> UsuariosDescartados { get; set; } = new List<string>();
	}
}
