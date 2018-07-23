using System;
using FindU.Models.Identity;

namespace FindU.Models
{
	public class Curtida
	{
		public string UsuarioId { get; set; }
		public virtual User Usuario { get; set; }
		public string UsuarioCurtidoId { get; set; }
		public virtual User UsuarioCurtido { get; set; }
		public DateTime Data { get; set; }
	}
}
