using FindU.Interfaces;
using FindU.Models;

namespace FindU.Infra.Data.Repositories
{
    public class CurtidaRepository : RepositoryBase<Curtida>, ICurtidaRepository
	{
		public CurtidaRepository(ApplicationDbContext context) : base(context)
		{
		}

		public Curtida GetById(string idUsuario, string idUsuarioCurtido)
		{
			return DbSet.Find(idUsuario, idUsuarioCurtido);
		}
	}
}
