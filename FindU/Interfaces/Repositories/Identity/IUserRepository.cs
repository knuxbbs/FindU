using FindU.Identity;

namespace FindU.Interfaces.Repositories.Identity
{
	public interface IUserRepository : IIdentityRepositoryBase<User, string>
	{
		User FindByNormalizedUserName(string normalizedUserName);

		User FindByNormalizedEmail(string normalizedEmail);
	}
}
