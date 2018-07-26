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

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult Roll(EstudanteRollViewModel estudanteRollViewModel)
		{
			var viewModel = _estudanteAppService.ObterEstudante(User, estudanteRollViewModel);

			return View(viewModel);
		}

		public IActionResult Like(string idUsuario)
		{
			_estudanteAppService.Curtir(User, idUsuario);

			return Json("foi");
		}
	}
}