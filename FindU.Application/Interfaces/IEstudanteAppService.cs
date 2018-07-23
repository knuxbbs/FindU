using FindU.Models;
using System.Collections.Generic;

namespace FindU.Application.Interfaces
{
	public interface IEstudanteAppService : IAppServiceBase<Estudante>
    {
		IEnumerable<OrientacaoPolitica> ListarOrientacoesPoliticas();
		IEnumerable<TipoDeAtracao> ListarTiposDeAtracao();
		IEnumerable<TipoDeConsumoBebida> ListarTiposDeConsumoBebida();
	}
}
