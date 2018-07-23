using FindU.Interfaces.Repositories.Identity;
using System.Linq;
using FindU.Models.Identity;

namespace FindU.Infra.Data.Repositories.Identity
{
	public class UserLoginRepository : IdentityRepositoryBase<UserLogin, UserLoginKey>, IUserLoginRepository
	{
		public UserLoginRepository(ApplicationDbContext context) : base(context)
		{
		}

		public new UserLogin GetById(UserLoginKey key)
		{
			return DbSet.Find(key.LoginProvider, key.ProviderKey);
		}

		public IQueryable<UserLogin> FindByUserId(string userId)
		{
			return DbSet.Where(c => c.UserId == userId);
		}
	}
}
