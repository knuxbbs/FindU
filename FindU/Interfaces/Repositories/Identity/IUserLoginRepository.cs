using FindU.Identity;
using System.Linq;

namespace FindU.Interfaces.Repositories.Identity
{
	public interface IUserLoginRepository : IIdentityRepositoryBase<UserLogin, UserLoginKey>
	{
		IQueryable<UserLogin> FindByUserId(string userId);
	}
}
