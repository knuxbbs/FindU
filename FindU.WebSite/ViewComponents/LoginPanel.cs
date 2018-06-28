using System.Linq;
using System.Threading.Tasks;
using FindU.Infra.Data.Identity.Configuration;
using FindU.WebSite.Models.AccountViewModels;
using Microsoft.AspNetCore.Identity;
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
