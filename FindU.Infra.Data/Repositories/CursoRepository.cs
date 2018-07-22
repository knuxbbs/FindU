using FindU.Interfaces;

namespace FindU.Infra.Data.Repositories
{
	public class CursoRepository : RepositoryBase<Curso>, ICursoRepository
	{
		public CursoRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
