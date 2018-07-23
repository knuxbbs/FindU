using FindU.Interfaces.Repositories.Identity;
using FindU.Models.Identity;

namespace FindU.Infra.Data.Repositories.Identity
{
	public class UserTokenRepository : IdentityRepositoryBase<UserToken, UserTokenKey>, IUserTokenRepository
	{
		public UserTokenRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
