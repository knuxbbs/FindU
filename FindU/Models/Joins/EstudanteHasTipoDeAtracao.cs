namespace FindU.Models.Joins
{
	public class EstudanteHasTipoDeAtracao
    {
		public int EstudanteId { get; set; }
		public virtual Estudante Estudante { get; set; }
		public int TipoDeAtracaoId { get; set; }
		public virtual TipoDeAtracao TipoDeAtracao { get; set; }
	}
}
