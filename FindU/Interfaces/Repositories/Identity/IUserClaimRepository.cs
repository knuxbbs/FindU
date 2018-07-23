using System.Linq;
using FindU.Models.Identity;

namespace FindU.Interfaces.Repositories.Identity
{
	public interface IUserClaimRepository : IIdentityRepositoryBase<UserClaim, int>
	{
		IQueryable<UserClaim> GetByUserId(string userId);
		IQueryable<User> GetUsersForClaim(string claimType, string claimValue);
	}
}
