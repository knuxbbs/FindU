using FindU.Application.Interfaces;
using FindU.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindU.WebSite.Controllers
{
	[Authorize]
	public class EstudanteController : Controller
	{
		private readonly IEstudanteAppService _estudanteAppService;

		public EstudanteController(IEstudanteAppService estudanteAppService)
		{
			_estudanteAppService = estudanteAppService;
		}

		[HttpGet]
		public IActionResult Roll()
		{
			var viewModel = _estudanteAppService.ObterEstudante(User);

			return viewModel == null ? View("EndOfRoll") : View(viewModel);
		}

		[HttpPost]
		public IActionResult Roll(EstudanteRollViewModel estudanteRollViewModel)
		{
			var viewModel = _estudanteAppService.ObterEstudante(User, estudanteRollViewModel);

			return viewModel == null ? View("EndOfRoll") : View(viewModel);
		}

		public IActionResult Like(string idUsuario)
		{
			var likeResult = _estudanteAppService.Curtir(User, idUsuario);

			return Json(likeResult);
		}

		public IActionResult Details(string idUsuario)
		{
			var estudanteDetailsViewModel = _estudanteAppService.ObterEstudanteCorrespondido(User, idUsuario);

			return View("MatchModal", estudanteDetailsViewModel);
		}

		public IActionResult Matches(string idUsuario)
		{
			var estudanteDetailsViewModel = _estudanteAppService.ListarEstudantesCorrespondidos(User);

			return View("MatchList", estudanteDetailsViewModel);
		}
	}
}