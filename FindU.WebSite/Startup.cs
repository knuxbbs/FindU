using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FindU.Infra.IoC;

namespace FindU.WebSite
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//Exibe as claims de maneira mais "amigável"
			JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

			//Adiciona o serviço de autenticação
			services.AddAuthentication(options =>
			{
				//Nosso esquema default será baseado em cookie
				options.DefaultScheme = "Cookies";

				//Como precisamos recuperar os dados depois do login, 
				//utilizamos o OpenID Connect que por padrão utiliza o escopo do Profile
				options.DefaultChallengeScheme = "oidc";
			})
			.AddCookie("Cookies")
			.AddOpenIdConnect("oidc", "UFBA", options =>
			{
				options.SignInScheme = "Cookies";

				//Aponta para o nosso servidor de autenticação
				options.Authority = "http://localhost:5000";
				options.RequireHttpsMetadata = false;

				//Nome da nossa aplicação que tentará se autenticar no nosso servidor de identidade
				//Observe que ela possui o mesmo nome da app que liberamos no nosso servidor de identidade
				options.ClientId = "79E0C2E2-D750-45BC-8FA3-1A9D5F9F82B5";
				options.SaveTokens = true;

				//Adicionamos o escopo do e-mail para utilizarmos a claim de e-mail.
				//options.Scope.Add(IdentityServerConstants.StandardScopes.Email);
				options.Scope.Add("email");
			})
			.AddFacebook(options =>
			{
				//TODO: Remover declaração explícita de credenciais
				//facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
				//facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];

				options.AppId = "999621133527975";
				options.AppSecret = "15c8b96503765f669ee7c7ebdfa283b1";
				options.Scope.Add("user_birthday");
				options.Scope.Add("user_gender");
				options.Scope.Add("user_location");
				options.Scope.Add("public_profile");
				options.Fields.Add("birthday");
				options.Fields.Add("gender");
				options.Fields.Add("picture");
			});

			services.AddMvc();

			RegisterServices(services, Configuration.GetConnectionString("DefaultConnection"));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseBrowserLink();
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseAuthentication();

			app.UseMvcWithDefaultRoute();
		}

		private static void RegisterServices(IServiceCollection services, string connection)
		{
			// Adding dependencies from another layers (isolated from Presentation)
			NativeInjectorBootStrapper.RegisterServices(services, connection);
		}
	}
}
