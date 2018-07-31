using System.Linq;
using FindU.Interfaces;
using FindU.Models;
using Microsoft.EntityFrameworkCore;

namespace FindU.Infra.Data.Repositories
{
	public class EstudanteRepository : RepositoryBase<Estudante>, IEstudanteRepository
	{
		public EstudanteRepository(ApplicationDbContext context) : base(context)
		{
		}

		public Estudante ObterPorUsuario(string idUsuario)
		{
			return DbSet
				.Include(x => x.Usuario)
				.SingleOrDefault(x => x.UsuarioId == idUsuario);
		}

		public IQueryable<Estudante> ListarPorGenero(Genero genero)
		{
			return DbSet.Where(x => x.Genero == genero);
		}

		public IQueryable<Estudante> ListarPorGenero(Genero genero, OrientacaoSexual orientacaoSexual)
		{
			return DbSet.Where(x => x.Genero == genero && x.OrientacaoSexual == orientacaoSexual);
		}
	}
}
