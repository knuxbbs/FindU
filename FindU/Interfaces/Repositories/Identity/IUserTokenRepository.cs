using FindU.Identity;

namespace FindU.Interfaces.Repositories.Identity
{
	public interface IUserTokenRepository : IIdentityRepositoryBase<UserToken, UserTokenKey>
	{
	}
}
