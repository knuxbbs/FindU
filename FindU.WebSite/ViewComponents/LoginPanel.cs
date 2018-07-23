using System.Threading.Tasks;
using FindU.Application.ViewModels.Identity.AccountViewModels;
using FindU.Infra.Data.Identity.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace FindU.WebSite.ViewComponents
{
	public class LoginPanel : ViewComponent
	{
		private readonly ApplicationSignInManager _signInManager;
		private readonly ApplicationUserManager _userManager;

		public LoginPanel(ApplicationSignInManager signInManager, ApplicationUserManager userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			if (_signInManager.IsSignedIn(HttpContext.User))
			{
				var user = await _userManager.GetUserAsync(HttpContext.User);
				return View("LoggedIn", user);
			}

			return View(new LoginViewModel());
		}
	}
}
