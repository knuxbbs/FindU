using FindU.Models.Joins;
using System.Collections.Generic;

namespace FindU.Models
{
	public class TipoDeAtracao
    {
		public int Id { get; set; }
		public string Nome { get; set; }
		public virtual IEnumerable<EstudanteHasTipoDeAtracao> Estudantes { get; set; }
	}
}
