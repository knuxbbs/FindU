using FindU.Interfaces;
using FindU.Models;

namespace FindU.Infra.Data.Repositories
{
	public class TipoDeAtracaoRepository : RepositoryBase<TipoDeAtracao>, ITipoDeAtracaoRepository
	{
		public TipoDeAtracaoRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
