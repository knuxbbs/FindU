﻿using System;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using FindU.Infra.Data.Identity.Configuration;
using FindU.Infra.Data.Identity.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FindU.Application;
using FindU.Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using FindU.Application.Components;
using FindU.Application.Extensions;
using FindU.Application.ViewModels.Identity.AccountViewModels;
using FindU.WebSite.Extensions;

namespace FindU.WebSite.Controllers
{
	[Authorize]
	[Route("[controller]/[action]")]
	public class AccountController : Controller
	{
		private readonly ApplicationUserManager _userManager;
		private readonly ApplicationSignInManager _signInManager;
		private readonly ICursoAppService _cursoAppService;
		private readonly IEstudanteAppService _estudanteAppService;
		private readonly IEmailSender _emailSender;
		private readonly ILogger _logger;

		public AccountController(
			ApplicationUserManager userManager,
			ApplicationSignInManager signInManager,
			ICursoAppService cursoAppService,
			IEstudanteAppService estudanteAppService,
			IEmailSender emailSender,
			ILogger<AccountController> logger)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_cursoAppService = cursoAppService;
			_estudanteAppService = estudanteAppService;
			_emailSender = emailSender;
			_logger = logger;
		}

		[TempData]
		public string ErrorMessage { get; set; }

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Login(string returnUrl = null)
		{
			// Clear the existing external cookie to ensure a clean login process
			await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

			ViewData["ReturnUrl"] = returnUrl;
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			if (ModelState.IsValid)
			{
				// This doesn't count login failures towards account lockout
				// To enable password failures to trigger account lockout, set lockoutOnFailure: true
				//var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

				var user = await _userManager.FindByNameAsync(model.Email);

				if (user == null) return View(model);

				await _signInManager.SignInAsync(user, true);

				//if (result.Succeeded)
				//{
				//	_logger.LogInformation("User logged in.");
				//	return RedirectToLocal(returnUrl);
				//}
				//if (result.RequiresTwoFactor)
				//{
				//	return RedirectToAction(nameof(LoginWith2fa), new { returnUrl, model.RememberMe });
				//}
				//if (result.IsLockedOut)
				//{
				//	_logger.LogWarning("User account locked out.");
				//	return RedirectToAction(nameof(Lockout));
				//}
				//else
				//{
				//	ModelState.AddModelError(string.Empty, "Invalid login attempt.");
				//	return View(model);
				//}

				return RedirectToAction(nameof(EstudanteController.Roll), "Estudante");
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> LoginWith2fa(bool rememberMe, string returnUrl = null)
		{
			// Ensure the user has gone through the username & password screen first
			var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();

			if (user == null)
			{
				throw new ApplicationException($"Unable to load two-factor authentication user.");
			}

			var model = new LoginWith2faViewModel { RememberMe = rememberMe };
			ViewData["ReturnUrl"] = returnUrl;

			return View(model);
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> LoginWith2fa(LoginWith2faViewModel model, bool rememberMe, string returnUrl = null)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
			if (user == null)
			{
				throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
			}

			var authenticatorCode = model.TwoFactorCode.Replace(" ", string.Empty).Replace("-", string.Empty);

			var result = await _signInManager.TwoFactorAuthenticatorSignInAsync(authenticatorCode, rememberMe, model.RememberMachine);

			if (result.Succeeded)
			{
				_logger.LogInformation("User with ID {UserId} logged in with 2fa.", user.Id);
				return RedirectToLocal(returnUrl);
			}
			else if (result.IsLockedOut)
			{
				_logger.LogWarning("User with ID {UserId} account locked out.", user.Id);
				return RedirectToAction(nameof(Lockout));
			}
			else
			{
				_logger.LogWarning("Invalid authenticator code entered for user with ID {UserId}.", user.Id);
				ModelState.AddModelError(string.Empty, "Invalid authenticator code.");
				return View();
			}
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> LoginWithRecoveryCode(string returnUrl = null)
		{
			// Ensure the user has gone through the username & password screen first
			var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
			if (user == null)
			{
				throw new ApplicationException($"Unable to load two-factor authentication user.");
			}

			ViewData["ReturnUrl"] = returnUrl;

			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> LoginWithRecoveryCode(LoginWithRecoveryCodeViewModel model, string returnUrl = null)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
			if (user == null)
			{
				throw new ApplicationException($"Unable to load two-factor authentication user.");
			}

			var recoveryCode = model.RecoveryCode.Replace(" ", string.Empty);

			var result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(recoveryCode);

			if (result.Succeeded)
			{
				_logger.LogInformation("User with ID {UserId} logged in with a recovery code.", user.Id);
				return RedirectToLocal(returnUrl);
			}
			if (result.IsLockedOut)
			{
				_logger.LogWarning("User with ID {UserId} account locked out.", user.Id);
				return RedirectToAction(nameof(Lockout));
			}
			else
			{
				_logger.LogWarning("Invalid recovery code entered for user with ID {UserId}", user.Id);
				ModelState.AddModelError(string.Empty, "Invalid recovery code entered.");
				return View();
			}
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult Lockout()
		{
			return View();
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult Register(string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
				var result = await _userManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{
					_logger.LogInformation("User created a new account with password.");

					var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
					var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
					await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

					await _signInManager.SignInAsync(user, isPersistent: false);
					_logger.LogInformation("User created a new account with password.");
					return RedirectToLocal(returnUrl);
				}
				AddErrors(result);
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			_logger.LogInformation("User logged out.");
			return RedirectToAction(nameof(HomeController.Index), "Home");
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public IActionResult ExternalLogin(string provider, string returnUrl = null)
		{
			// Request a redirect to the external login provider.
			var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
			var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
			return Challenge(properties, provider);
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
		{
			if (remoteError != null)
			{
				ErrorMessage = $"Error from external provider: {remoteError}";
				return RedirectToAction(nameof(Login));
			}

			var info = await _signInManager.GetExternalLoginInfoAsync();

			if (info == null)
			{
				return RedirectToAction(nameof(Login));
			}

			//Verifica se usuário já está cadastrado na base de dados da aplicação
			var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider,
				info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

			if (result.Succeeded)
			{
				_logger.LogInformation("User logged in with {Name} provider.", info.LoginProvider);
				return RedirectToAction(nameof(EstudanteController.Roll), "Estudante");
			}

			if (result.IsLockedOut)
			{
				return RedirectToAction(nameof(Lockout));
			}

			// If the user does not have an account, then ask the user to create an account.
			ViewData["ReturnUrl"] = returnUrl;
			ViewData["LoginProvider"] = info.LoginProvider;

			var email = info.Principal.FindFirstValue(ClaimTypes.Email);
			var phone = info.Principal.FindFirstValue(ClaimTypes.MobilePhone);
			var name = info.Principal.FindFirstValue(ClaimTypes.GivenName);
			var surname = info.Principal.FindFirstValue(ClaimTypes.Surname);
			var birthday = info.Principal.FindFirstValue(ClaimTypes.DateOfBirth);
			var gender = info.Principal.FindFirstValue(ClaimTypes.Gender);
			var location = info.Principal.FindFirstValue(ClaimTypes.Locality);
			var identifier = info.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
			var picture = $"https://graph.facebook.com/{identifier}/picture?type=large";

			var externalLoginViewModel = new ExternalLoginViewModel
			{
				GeneroId = gender == "male" ? 1 : gender == "female" ? 2 : 1,
				Nome = name,
				Sobrenome = surname,
				DataNascimento = DateTime.Parse(birthday, new CultureInfo("en-US")),
				Email = email,
				PhoneNumber = phone,
				Localizacao = location,
				CaminhoFoto = picture,
				Cursos = new SelectList(_cursoAppService.GetAll().OrderBy(x => x.Nome),
					"Id",
					"Nome"),
				OrientacoesPoliticas = new SelectList(_estudanteAppService.ListarOrientacoesPoliticas(),
					"Id",
					"Nome"),
				TiposDeConsumoBebida = new SelectList(_estudanteAppService.ListarTiposDeConsumoBebida(),
					"Id",
					"Nome"),
				TiposDeAtracao = _estudanteAppService.ListarTiposDeAtracao().Select(x =>
					new CheckBoxListItem
					{
						Id = x.Id,
						Text = x.Nome
					}).ToArray(),
				GenerosInteresse = new[]
					{
						new CheckBoxListItem{Id = 1, Text = "Homens"},
						new CheckBoxListItem{Id = 2, Text = "Mulheres"},
					}
			};

			return View(nameof(ExternalLogin), externalLoginViewModel);
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginViewModel model, string returnUrl = null)
		{
			if (ModelState.IsValid)
			{
				// Get the information about the user from the external login provider
				var info = await _signInManager.GetExternalLoginInfoAsync();

				if (info == null)
				{
					throw new ApplicationException("Error loading external login information during confirmation.");
				}

				var estudante = await _estudanteAppService.Add(model, info);

				if (estudante == null) return View(nameof(ExternalLogin), model);

				var applicationUser = await _userManager.FindByEmailAsync(estudante.Usuario.UserName);

				await _signInManager.SignInAsync(applicationUser, false);
				_logger.LogInformation("User created an account using {Name} provider.", info.LoginProvider);
				return RedirectToAction(nameof(RegisterConfirmation));
			}

			ViewData["ReturnUrl"] = returnUrl;
			return View(nameof(ExternalLogin), model);
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult RegisterConfirmation()
		{
			return View();
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> ConfirmEmail(string userId, string code)
		{
			if (userId == null || code == null)
			{
				return RedirectToAction(nameof(HomeController.Index), "Home");
			}
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
			{
				throw new ApplicationException($"Unable to load user with ID '{userId}'.");
			}
			var result = await _userManager.ConfirmEmailAsync(user, code);
			return View(result.Succeeded ? "ConfirmEmail" : "Error");
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult ForgotPassword()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(model.Email);
				if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
				{
					// Don't reveal that the user does not exist or is not confirmed
					return RedirectToAction(nameof(ForgotPasswordConfirmation));
				}

				// For more information on how to enable account confirmation and password reset please
				// visit https://go.microsoft.com/fwlink/?LinkID=532713
				var code = await _userManager.GeneratePasswordResetTokenAsync(user);
				var callbackUrl = Url.ResetPasswordCallbackLink(user.Id, code, Request.Scheme);
				await _emailSender.SendEmailAsync(model.Email, "Reset Password",
				   $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");
				return RedirectToAction(nameof(ForgotPasswordConfirmation));
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult ForgotPasswordConfirmation()
		{
			return View();
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult ResetPassword(string code = null)
		{
			if (code == null)
			{
				throw new ApplicationException("A code must be supplied for password reset.");
			}
			var model = new ResetPasswordViewModel { Code = code };
			return View(model);
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var user = await _userManager.FindByEmailAsync(model.Email);
			if (user == null)
			{
				// Don't reveal that the user does not exist
				return RedirectToAction(nameof(ResetPasswordConfirmation));
			}
			var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
			if (result.Succeeded)
			{
				return RedirectToAction(nameof(ResetPasswordConfirmation));
			}
			AddErrors(result);
			return View();
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult ResetPasswordConfirmation()
		{
			return View();
		}


		[HttpGet]
		public IActionResult AccessDenied()
		{
			return View();
		}

		[HttpGet]
		[AllowAnonymous]
		public JsonResult ValidarMatricula(string matricula, int cursoId)
		{
			var curso = _cursoAppService.GetById(cursoId);

			if (curso == null || string.IsNullOrEmpty(matricula))
			{
				return Json(true);
			}

			if (matricula.Length < 9)
			{
				return Json("Matrícula inválida.");
			}

			var dataImporter = new SupacDataImporter();

			try
			{
				if (!dataImporter.ValidarMatricula(matricula, curso))
				{
					return Json("Matrícula inválida.");
				}
			}
			catch (Exception)
			{
				return Json("Não foi possível validar a matrícula.");
			}

			return Json(true);
		}

		#region Helpers

		private void AddErrors(IdentityResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(string.Empty, error.Description);
			}
		}

		private IActionResult RedirectToLocal(string returnUrl)
		{
			if (Url.IsLocalUrl(returnUrl))
			{
				return Redirect(returnUrl);
			}
			else
			{
				return RedirectToAction(nameof(HomeController.Index), "Home");
			}
		}

		#endregion
	}
}
