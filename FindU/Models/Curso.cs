namespace FindU
{
    public class Curso
    {
	    public int Id { get; set; }
	    public string Nome { get; set; }

		public int CodigoSupac { get; set; }
		public UnidadeUniversitaria UnidadeUniversitaria { get; set; }
	    public int UnidadeUniversitariaId { get; set; }

		//TODO: Inserir propriedade 'Turno'
    }
}
