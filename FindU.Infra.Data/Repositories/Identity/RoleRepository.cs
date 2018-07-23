using FindU.Interfaces.Repositories.Identity;
using System.Linq;
using FindU.Models.Identity;

namespace FindU.Infra.Data.Repositories.Identity
{
	public class RoleRepository : IdentityRepositoryBase<Role, string>, IRoleRepository
	{
		public RoleRepository(ApplicationDbContext context) : base(context)
		{
		}

		public Role FindByName(string roleName)
		{
			return DbSet.SingleOrDefault(c => c.Name == roleName);
		}
	}
}
