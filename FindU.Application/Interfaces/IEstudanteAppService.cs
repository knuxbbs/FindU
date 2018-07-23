using FindU.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindU.Application.ViewModels.Identity.AccountViewModels;

namespace FindU.Application.Interfaces
{
	public interface IEstudanteAppService : IAppServiceBase<Estudante>
	{
		Task<Estudante> Add(ExternalLoginViewModel model);
		IEnumerable<OrientacaoPolitica> ListarOrientacoesPoliticas();
		IEnumerable<TipoDeAtracao> ListarTiposDeAtracao();
		IEnumerable<TipoDeConsumoBebida> ListarTiposDeConsumoBebida();
	}
}
