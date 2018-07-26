using FindU.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using FindU.Application.ViewModels;
using FindU.Application.ViewModels.Identity.AccountViewModels;
using Microsoft.AspNetCore.Identity;

namespace FindU.Application.Interfaces
{
	public interface IEstudanteAppService : IAppServiceBase<Estudante>
	{
		Task<Estudante> Add(ExternalLoginViewModel model, ExternalLoginInfo info);
		EstudanteRollViewModel ObterEstudante(ClaimsPrincipal user, EstudanteRollViewModel previousViewModel = null);
		bool Curtir(ClaimsPrincipal user, string idUsuarioCurtido);
		IEnumerable<OrientacaoPolitica> ListarOrientacoesPoliticas();
		IEnumerable<TipoDeAtracao> ListarTiposDeAtracao();
		IEnumerable<TipoDeConsumoBebida> ListarTiposDeConsumoBebida();
	}
}
