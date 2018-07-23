using FindU.Interfaces;

namespace FindU.Infra.Data.Repositories
{
	public class EstudanteRepository : RepositoryBase<Estudante>, IEstudanteRepository
	{
		public EstudanteRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
