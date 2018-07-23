using FindU.Interfaces.Repositories.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using FindU.Models.Identity;

namespace FindU.Infra.Data.Repositories.Identity
{
	public class UserClaimRepository : IdentityRepositoryBase<UserClaim, int>, IUserClaimRepository
	{
		private readonly DbSet<User> _userDbSet;

		public UserClaimRepository(ApplicationDbContext context) : base(context)
		{
			_userDbSet = context.Set<User>();
		}

		public IQueryable<UserClaim> GetByUserId(string userId)
		{
			return DbSet.Where(c => c.UserId == userId);
		}

		public IQueryable<User> GetUsersForClaim(string claimType, string claimValue)
		{
			return DbSet.Join(_userDbSet, userClaim => userClaim.UserId, user => user.Id,
					(userClaim, user) => new { userClaim, user })
				.Where(c => c.userClaim.ClaimType == claimType && c.userClaim.ClaimValue == claimValue)
				.Select(c => c.user);

			//return from userClaim in DbSet
			//	join user in _userDbSet on userClaim.UserId equals user.Id
			//	where userClaim.ClaimType == claimType && userClaim.ClaimValue == claimValue
			//	select user;
		}
	}
}
