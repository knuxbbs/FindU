using FindU.Interfaces;

namespace FindU.Infra.Data.Repositories
{
	public class OrientacaoPoliticaRepository : RepositoryBase<OrientacaoPolitica>, IOrientacaoPoliticaRepository
	{
		public OrientacaoPoliticaRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
