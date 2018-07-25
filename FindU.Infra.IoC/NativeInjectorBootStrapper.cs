using FindU.Application.Interfaces;
using FindU.Application.Services;
using FindU.Infra.Data;
using FindU.Infra.Data.Identity.Configuration;
using FindU.Infra.Data.Identity.Models;
using FindU.Infra.Data.Repositories;
using FindU.Infra.Data.Repositories.Identity;
using FindU.Infra.IoC.Extensions;
using FindU.Interfaces;
using FindU.Interfaces.Repositories.Identity;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FindU.Infra.IoC
{
	public class NativeInjectorBootStrapper
    {
		public static void RegisterServices(IServiceCollection services, string connection)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(connection));

			services.AddIdentity<ApplicationUser, ApplicationRole>()
				.AddCustomStores()
				.AddDefaultTokenProviders();

			//Infra - Identity
			services.AddScoped<IRoleClaimRepository, RoleClaimRepository>();
			services.AddScoped<IRoleRepository, RoleRepository>();
			services.AddScoped<IUserClaimRepository, UserClaimRepository>();
			services.AddScoped<IUserLoginRepository, UserLoginRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IUserRoleRepository, UserRoleRepository>();
			services.AddScoped<IUserTokenRepository, UserTokenRepository>();

			services.AddScoped<ApplicationUserManager>();
			services.AddScoped<ApplicationRoleManager>();
			services.AddScoped<ApplicationSignInManager>();

			// Register no-op EmailSender used by account confirmation and password reset during development
			// For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=532713
			services.AddSingleton<IEmailSender, EmailSender>();

			//Infra - Data
			services.AddScoped<ICursoAppService, CursoAppService>();
			services.AddScoped<ICursoRepository, CursoRepository>();
			services.AddScoped<IEstudanteAppService, EstudanteAppService>();
			services.AddScoped<IEstudanteRepository, EstudanteRepository>();
			services.AddScoped<IOrientacaoPoliticaRepository, OrientacaoPoliticaRepository>();
			services.AddScoped<ITipoDeConsumoBebidaRepository, TipoDeConsumoBebidaRepository>();
			services.AddScoped<ITipoDeAtracaoRepository, TipoDeAtracaoRepository>();
		}

	    public static void RegisterServicesForTest(IServiceCollection services, string connection)
	    {
		    services.AddSingleton<IHostingEnvironment>(new HostingEnvironment());

			RegisterServices(services, connection);
		}
	}
}
