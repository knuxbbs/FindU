using FindU.Interfaces;
using FindU.Models;

namespace FindU.Infra.Data.Repositories
{
    public class CurtidaRepository : RepositoryBase<Curtida>, ICurtidaRepository
	{
		public CurtidaRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
