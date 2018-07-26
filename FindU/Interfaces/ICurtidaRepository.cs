using FindU.Models;

namespace FindU.Interfaces
{
    public interface ICurtidaRepository : IRepositoryBase<Curtida>
    {
	    Curtida GetById(string idUsuario, string idUsuarioCurtido);
    }
}
