using System.Collections.Generic;
using System.Linq;
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

		public IEnumerable<Curtida> ObterMatchesPorUsuario(string idUsuario)
		{
			IList<Curtida> matches = new List<Curtida>();

			var curtidas = DbSet.Where(x => x.UsuarioId == idUsuario);

			foreach (var curtida in curtidas)
			{
				var match = DbSet.Find(curtida.UsuarioCurtidoId, idUsuario);

				if (match != null) matches.Add(match);
			}

			return matches;
		}
	}
}
