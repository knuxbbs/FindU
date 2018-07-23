using System.Linq;
using FindU.Models.Identity;

namespace FindU.Interfaces.Repositories.Identity
{
	public interface IUserLoginRepository : IIdentityRepositoryBase<UserLogin, UserLoginKey>
	{
		IQueryable<UserLogin> FindByUserId(string userId);
	}
}
