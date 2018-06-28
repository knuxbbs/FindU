using Microsoft.AspNetCore.Identity;

namespace FindU.Infra.Data.Identity.Models
{
	public class ApplicationRole : IdentityRole
	{
		public ApplicationRole()
		{
		}

		public ApplicationRole(string roleName) : base(roleName)
		{
		}
	}
}
