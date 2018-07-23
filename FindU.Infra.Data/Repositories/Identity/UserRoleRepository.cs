using FindU.Interfaces.Repositories.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using FindU.Models.Identity;

namespace FindU.Infra.Data.Repositories.Identity
{
	public class UserRoleRepository : IUserRoleRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly DbSet<User> _userDbSet;
		private readonly DbSet<Role> _roleDbSet;
		private readonly DbSet<UserRole> _userRoleDbSet;

		public UserRoleRepository(ApplicationDbContext context)
		{
			_context = context;
			_userDbSet = _context.Set<User>();
			_roleDbSet = _context.Set<Role>();
			_userRoleDbSet = _context.Set<UserRole>();
		}

		public void Add(string userId, string roleName)
		{
			const string commandText = "INSERT INTO AspNetUserRoles(UserId, RoleId) " +
									   "SELECT TOP 1 @userId, Id FROM AspNetRoles " +
									   "WHERE NormalizedName = @roleName";

			var param0 = new SqlParameter("@userId", userId);
			var param1 = new SqlParameter("@roleName", roleName);

			_context.Database.ExecuteSqlCommand(commandText, param0, param1);
		}

		public void Remove(string userId, string roleName)
		{
			const string commandText = "DELETE ur FROM AspNetUserRoles ur " +
									   "INNER JOIN AspNetRoles r ON ur.RoleId = r.Id " +
									   "WHERE ur.UserId = @userId " +
									   "AND r.NormalizedName = @roleName";

			var param0 = new SqlParameter("@userId", userId);
			var param1 = new SqlParameter("@roleName", roleName);

			_context.Database.ExecuteSqlCommand(commandText, param0, param1);
		}

		public IQueryable<string> GetRoleNamesByUserId(string userId)
		{
			return _userRoleDbSet.Join(_roleDbSet, userRole => userRole.RoleId, role => role.Id,
					(userRole, role) => new { userRole, role })
				.Where(c => c.userRole.UserId == userId).Select(c => c.role.Name);
		}

		public IQueryable<User> GetUsersByRoleName(string roleName)
		{
			var commandText = new StringBuilder("SELECT u.* FROM AspNetUserRoles ur ")
				.Append("INNER JOIN AspNetRoles r ON ur.RoleId = r.Id ")
				.Append("INNER JOIN AspNetUsers u ON ur.UserId = u.Id ")
				.AppendFormat("WHERE r.NormalizedName = {0}", roleName);

			return _userDbSet.FromSql(commandText.ToString());
		}
	}
}
