using FindU.Identity;
using FindU.Interfaces.Repositories.Identity;
using System.Linq;

namespace FindU.Infra.Data.Repositories.Identity
{
	public class UserRepository : IdentityRepositoryBase<User, string>, IUserRepository
	{
		public UserRepository(ApplicationDbContext context) : base(context)
		{
		}

		public User FindByNormalizedUserName(string normalizedUserName)
		{
			return DbSet.SingleOrDefault(c => c.NormalizedUserName == normalizedUserName);
		}

		public User FindByNormalizedEmail(string normalizedEmail)
		{
			return DbSet.SingleOrDefault(c => c.NormalizedEmail == normalizedEmail);
		}
	}
}
