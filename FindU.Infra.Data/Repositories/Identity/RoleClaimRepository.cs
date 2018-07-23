using FindU.Interfaces.Repositories.Identity;
using System.Linq;
using FindU.Models.Identity;

namespace FindU.Infra.Data.Repositories.Identity
{
	public class RoleClaimRepository : IdentityRepositoryBase<RoleClaim, int>, IRoleClaimRepository
	{
		public RoleClaimRepository(ApplicationDbContext context) : base(context)
		{
		}

		public IQueryable<RoleClaim> FindByRoleId(string roleId)
		{
			return DbSet.Where(c => c.RoleId == roleId);
		}
	}
}
