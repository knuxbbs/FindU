using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace Ufba.IdentityServer
{
	public class IdentityServerConfiguration
	{
		/// <summary>
		/// Define recursos que serão utilizados pelo servidor
		/// </summary>
		/// <returns></returns>
		public static IEnumerable<IdentityResource> GetIdentityResources()
		{
			return new List<IdentityResource>()
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Profile(),
				new IdentityResources.Email()
			};
		}

		/// <summary>
		/// Define quais aplicações poderão acessar o servidor de identidade.
		/// </summary>
		/// <returns></returns>
		public static IEnumerable<Client> GetClientScope()
		{
			return new List<Client>()
		   {
			   new Client()
			   {
				   ClientId = "79E0C2E2-D750-45BC-8FA3-1A9D5F9F82B5",
				   ClientName = "FindU",
				   //Tipos de autenticação permitidas
				   AllowedGrantTypes = GrantTypes.Implicit,
				   AllowedScopes =
				   {
					   IdentityServerConstants.StandardScopes.OpenId,
					   IdentityServerConstants.StandardScopes.Profile,
					   IdentityServerConstants.StandardScopes.Email
				   },
				   //Url de redicionamento para quando o login for efetuado com sucesso.
				   RedirectUris = { "http://localhost:5001/signin-oidc" },
				   //Url de redirecionamento para quando o logout for efetuado com sucesso.
				   PostLogoutRedirectUris = { "http://localhost:5001" }
			   }
		   };
		}

		public static IEnumerable<TestUser> GetUsers()
		{
			// TestUser é uma classe de exemplo do próprio IdentityServer, aonde configuramos login/senha e as claims de exibição.

			yield return new TestUser()
			{
				SubjectId = "AAF38B9A-4989-4B8E-B6F5-3B6928CF36C1",
				Username = "knuxbbs",
				Password = "123456",
				Claims = new List<Claim>()
				{
					new Claim("name", "Tester User"),
				}
			};
		}
	}
}
