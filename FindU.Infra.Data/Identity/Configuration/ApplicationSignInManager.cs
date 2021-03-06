﻿using FindU.Infra.Data.Identity.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FindU.Infra.Data.Identity.Configuration
{
	public class ApplicationSignInManager : SignInManager<ApplicationUser>
	{
		public ApplicationSignInManager(ApplicationUserManager userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<ApplicationUser>> logger, IAuthenticationSchemeProvider schemes)
			: base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
		{
		}
	}
}
