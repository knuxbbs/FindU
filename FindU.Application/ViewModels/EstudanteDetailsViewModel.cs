using System.ComponentModel.DataAnnotations;

namespace FindU.Application.ViewModels
{
    public class EstudanteDetailsViewModel
    {
	    public string Nome { get; set; }
	    public string Curso { get; set; }
		[Display(Name = "Telefone")]
	    public string PhoneNumber { get; set; }
	    public string Facebook { get; set; }
	    public string UsuarioId { get; set; }
    }
}
