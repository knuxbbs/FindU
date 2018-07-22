using FindU.Identity;
using System;

namespace FindU
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
