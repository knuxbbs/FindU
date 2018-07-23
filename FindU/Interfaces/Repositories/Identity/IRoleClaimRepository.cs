using System.Linq;
using FindU.Models.Identity;

namespace FindU.Interfaces.Repositories.Identity
{
	public interface IRoleClaimRepository : IIdentityRepositoryBase<RoleClaim, int>
	{
		IQueryable<RoleClaim> FindByRoleId(string roleId);
	}
}
