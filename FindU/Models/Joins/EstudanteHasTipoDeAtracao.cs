namespace FindU.Models.Joins
{
	public class EstudanteHasTipoDeAtracao
    {
		public int EstudanteId { get; set; }
		public Estudante Estudante { get; set; }
		public int TipoDeAtracaoId { get; set; }
		public TipoDeAtracao TipoDeAtracao { get; set; }
	}
}
