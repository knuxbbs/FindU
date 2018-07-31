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
		string SavePhoto(string emailUsuario, string photoUrl);
		Task<string> SavePhotoAsync(string emailUsuario, string photoUrl);
		EstudanteRollViewModel ObterEstudante(ClaimsPrincipal user, EstudanteRollViewModel previousViewModel = null);
		LikeResultViewModel Curtir(ClaimsPrincipal user, string idUsuarioCurtido);
		EstudanteDetailsViewModel ObterEstudanteCorrespondido(ClaimsPrincipal user, string idUsuarioCurtido);
		IEnumerable<EstudanteDetailsViewModel> ListarEstudantesCorrespondidos(ClaimsPrincipal user);
		IEnumerable<OrientacaoPolitica> ListarOrientacoesPoliticas();
		IEnumerable<TipoDeAtracao> ListarTiposDeAtracao();
		IEnumerable<TipoDeConsumoBebida> ListarTiposDeConsumoBebida();
	}
}
