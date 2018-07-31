using System.Diagnostics;
using FindU.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FindU.WebSite.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			if (User.Identity.IsAuthenticated)
			{
				return RedirectToAction(nameof(EstudanteController.Roll), "Estudante");
			}

			return View();
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
