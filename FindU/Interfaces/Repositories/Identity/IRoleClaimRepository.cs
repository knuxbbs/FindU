using FindU.Identity;
using System.Linq;

namespace FindU.Interfaces.Repositories.Identity
{
	public interface IRoleClaimRepository : IIdentityRepositoryBase<RoleClaim, int>
	{
		IQueryable<RoleClaim> FindByRoleId(string roleId);
	}
}
