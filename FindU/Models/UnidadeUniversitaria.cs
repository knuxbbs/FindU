namespace FindU.Models
{
    public class UnidadeUniversitaria
    {
	    public int Id { get; set; }
	    public string Nome { get; set; }
	    public virtual AreaConhecimento AreaConhecimento { get; set; }
	    public int AreaConhecimentoId { get; set; }
    }
}
