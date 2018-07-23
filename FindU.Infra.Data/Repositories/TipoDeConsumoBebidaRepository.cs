using FindU.Interfaces;
using FindU.Models;

namespace FindU.Infra.Data.Repositories
{
	public class TipoDeConsumoBebidaRepository : RepositoryBase<TipoDeConsumoBebida>, ITipoDeConsumoBebidaRepository
	{
		public TipoDeConsumoBebidaRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
