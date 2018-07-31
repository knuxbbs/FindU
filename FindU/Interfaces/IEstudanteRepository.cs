using System.Linq;
using FindU.Models;

namespace FindU.Interfaces
{
	public interface IEstudanteRepository : IRepositoryBase<Estudante>
	{
		Estudante ObterPorUsuario(string idUsuario);
		IQueryable<Estudante> ListarPorGenero(Genero genero);
		IQueryable<Estudante> ListarPorGenero(Genero genero, OrientacaoSexual orientacaoSexual);
	}
}
