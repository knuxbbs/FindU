using FindU.Models.Identity;

namespace FindU.Interfaces.Repositories.Identity
{
	public interface IRoleRepository : IIdentityRepositoryBase<Role, string>
	{
		Role FindByName(string roleName);
	}
}
