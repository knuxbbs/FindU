using FindU.Identity;
using System.Linq;

namespace FindU.Interfaces.Repositories.Identity
{
	public interface IUserRoleRepository
	{
		void Add(string userId, string roleName);
		void Remove(string userId, string roleName);
		IQueryable<string> GetRoleNamesByUserId(string userId);
		IQueryable<User> GetUsersByRoleName(string roleName);
	}
}
