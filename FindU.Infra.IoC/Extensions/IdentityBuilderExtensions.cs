using FindU.Infra.Data.Identity.Configuration;
using FindU.Infra.Data.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace FindU.Infra.IoC.Extensions
{
	public static class IdentityBuilderExtensions
	{
		public static IdentityBuilder AddCustomStores(this IdentityBuilder builder)
		{
			builder.Services.AddTransient<IUserStore<ApplicationUser>, ApplicationUserStore>();
			builder.Services.AddTransient<IRoleStore<ApplicationRole>, ApplicationRoleStore>();

			return builder;
		}
	}
}
