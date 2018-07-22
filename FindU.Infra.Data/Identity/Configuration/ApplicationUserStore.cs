using FindU.Identity;
using FindU.Infra.Data.Identity.Models;
using FindU.Interfaces.Repositories.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace FindU.Infra.Data.Identity.Configuration
{
	public class ApplicationUserStore :
		IUserPasswordStore<ApplicationUser>,
		IUserEmailStore<ApplicationUser>,
		IUserLoginStore<ApplicationUser>,
		IUserRoleStore<ApplicationUser>,
		IUserSecurityStampStore<ApplicationUser>,
		IUserClaimStore<ApplicationUser>,
		IUserAuthenticationTokenStore<ApplicationUser>,
		IUserTwoFactorStore<ApplicationUser>,
		IUserPhoneNumberStore<ApplicationUser>,
		IUserLockoutStore<ApplicationUser>,
		IQueryableUserStore<ApplicationUser>
	{
		private readonly IUserRepository _userRepository;
		private readonly IUserLoginRepository _userLoginRepository;
		private readonly IUserRoleRepository _userRoleRepository;
		private readonly IUserClaimRepository _userClaimRepository;
		private readonly IUserTokenRepository _userTokenRepository;

		public ApplicationUserStore(IUserRepository userRepository, IUserLoginRepository userLoginRepository,
			IUserRoleRepository userRoleRepository, IUserClaimRepository userClaimRepository, IUserTokenRepository userTokenRepository)
		{
			_userRepository = userRepository;
			_userLoginRepository = userLoginRepository;
			_userRoleRepository = userRoleRepository;
			_userClaimRepository = userClaimRepository;
			_userTokenRepository = userTokenRepository;
		}

		#region IQueryableUserStore<ApplicationUser> Members

		public IQueryable<ApplicationUser> Users
		{
			get
			{
				return _userRepository.GetAll()
					.Select(x => GetApplicationUser(x))
					.AsQueryable();
			}
		}

		#endregion

		#region IUserStore<ApplicationUser> Members

		public Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
		{
			try
			{
				cancellationToken.ThrowIfCancellationRequested();

				if (user == null)
					throw new ArgumentNullException(nameof(user));

				var userEntity = GetUserEntity(user);

				_userRepository.Add(userEntity);

				return Task.FromResult(IdentityResult.Success);
			}
			catch (Exception ex)
			{
				return Task.FromResult(IdentityResult.Failed(new IdentityError { Code = ex.Message, Description = ex.Message }));
			}
		}

		public Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
		{
			try
			{
				cancellationToken.ThrowIfCancellationRequested();

				if (user == null)
					throw new ArgumentNullException(nameof(user));

				var userEntity = GetUserEntity(user);

				_userRepository.Remove(userEntity.Id);

				return Task.FromResult(IdentityResult.Success);
			}
			catch (Exception ex)
			{
				return Task.FromResult(IdentityResult.Failed(new IdentityError { Code = ex.Message, Description = ex.Message }));
			}
		}

		public Task<ApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (string.IsNullOrWhiteSpace(userId))
				throw new ArgumentNullException(nameof(userId));

			if (!Guid.TryParse(userId, out var id))
				throw new ArgumentOutOfRangeException(nameof(userId), $"{nameof(userId)} is not a valid GUID");

			var userEntity = _userRepository.GetById(id.ToString());

			return Task.FromResult(GetApplicationUser(userEntity));
		}

		public Task<ApplicationUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			var userEntity = _userRepository.FindByNormalizedUserName(normalizedUserName);

			return Task.FromResult(GetApplicationUser(userEntity));
		}

		public Task<string> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			return Task.FromResult(user.NormalizedUserName);
		}

		public Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			return Task.FromResult(user.Id);
		}

		public Task<string> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			return Task.FromResult(user.UserName);
		}

		public Task SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			user.NormalizedUserName = normalizedName;

			return Task.CompletedTask;
		}

		public Task SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			user.UserName = userName;

			return Task.CompletedTask;
		}

		public Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
		{
			try
			{
				cancellationToken.ThrowIfCancellationRequested();

				if (user == null)
					throw new ArgumentNullException(nameof(user));

				var userEntity = GetUserEntity(user);

				_userRepository.Update(userEntity);

				return Task.FromResult(IdentityResult.Success);
			}
			catch (Exception ex)
			{
				return Task.FromResult(IdentityResult.Failed(new IdentityError { Code = ex.Message, Description = ex.Message }));
			}
		}

		public void Dispose()
		{
			// Lifetimes of dependencies are managed by the IoC container, so disposal here is unnecessary.
		}

		#endregion

		#region IUserPasswordStore<ApplicationUser> Members
		public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			user.PasswordHash = passwordHash;

			return Task.CompletedTask;
		}

		public Task<string> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			return Task.FromResult(user.PasswordHash);
		}

		public Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			return Task.FromResult(!string.IsNullOrWhiteSpace(user.PasswordHash));
		}

		#endregion

		#region IUserEmailStore<ApplicationUser> Members

		public Task SetEmailAsync(ApplicationUser user, string email, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			user.Email = email;

			return Task.CompletedTask;
		}

		public Task<string> GetEmailAsync(ApplicationUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			return Task.FromResult(user.Email);
		}

		public Task<bool> GetEmailConfirmedAsync(ApplicationUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			return Task.FromResult(user.EmailConfirmed);
		}

		public Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			user.EmailConfirmed = confirmed;

			return Task.CompletedTask;
		}

		public Task<ApplicationUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
		{
			if (string.IsNullOrWhiteSpace(normalizedEmail))
				throw new ArgumentNullException(nameof(normalizedEmail));

			var userEntity = _userRepository.FindByNormalizedEmail(normalizedEmail);

			return Task.FromResult(GetApplicationUser(userEntity));
		}

		public Task<string> GetNormalizedEmailAsync(ApplicationUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			return Task.FromResult(user.NormalizedEmail);
		}

		public Task SetNormalizedEmailAsync(ApplicationUser user, string normalizedEmail, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			user.NormalizedEmail = normalizedEmail;

			return Task.CompletedTask;
		}
		#endregion

		#region IUserLoginStore<ApplicationUser> Members
		public Task AddLoginAsync(ApplicationUser user, UserLoginInfo login, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (login == null)
				throw new ArgumentNullException(nameof(login));

			if (string.IsNullOrWhiteSpace(login.LoginProvider))
				throw new ArgumentNullException(nameof(login.LoginProvider));

			if (string.IsNullOrWhiteSpace(login.ProviderKey))
				throw new ArgumentNullException(nameof(login.ProviderKey));

			var loginEntity = new UserLogin
			{
				LoginProvider = login.LoginProvider,
				ProviderDisplayName = login.ProviderDisplayName,
				ProviderKey = login.ProviderKey,
				UserId = user.Id
			};

			_userLoginRepository.Add(loginEntity);

			return Task.CompletedTask;
		}

		public Task RemoveLoginAsync(ApplicationUser user, string loginProvider, string providerKey, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (string.IsNullOrWhiteSpace(loginProvider))
				throw new ArgumentNullException(nameof(loginProvider));

			if (string.IsNullOrWhiteSpace(providerKey))
				throw new ArgumentNullException(nameof(providerKey));

			_userLoginRepository.Remove(new UserLoginKey { LoginProvider = loginProvider, ProviderKey = providerKey });

			return Task.CompletedTask;
		}

		public Task<IList<UserLoginInfo>> GetLoginsAsync(ApplicationUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			IList<UserLoginInfo> result = _userLoginRepository.FindByUserId(user.Id)
				.Select(x => new UserLoginInfo(x.LoginProvider, x.ProviderKey, x.ProviderDisplayName))
				.ToList();

			return Task.FromResult(result);
		}

		public Task<ApplicationUser> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (string.IsNullOrWhiteSpace(loginProvider))
				throw new ArgumentNullException(nameof(loginProvider));

			if (string.IsNullOrWhiteSpace(providerKey))
				throw new ArgumentNullException(nameof(providerKey));

			var loginEntity =
				_userLoginRepository.GetById(new UserLoginKey { LoginProvider = loginProvider, ProviderKey = providerKey });

			if (loginEntity == null)
				return Task.FromResult(default(ApplicationUser));

			var userEntity = _userRepository.GetById(loginEntity.UserId);

			return Task.FromResult(GetApplicationUser(userEntity));
		}
		#endregion

		#region IUserRoleStore<ApplicationUser> Members

		public Task AddToRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (string.IsNullOrWhiteSpace(roleName))
				throw new ArgumentNullException(nameof(roleName));

			_userRoleRepository.Add(user.Id, roleName);

			return Task.CompletedTask;
		}

		public Task RemoveFromRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (string.IsNullOrWhiteSpace(roleName))
				throw new ArgumentNullException(nameof(roleName));

			_userRoleRepository.Remove(user.Id, roleName);

			return Task.CompletedTask;
		}

		public Task<IList<string>> GetRolesAsync(ApplicationUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			IList<string> result = _userRoleRepository.GetRoleNamesByUserId(user.Id).ToList();

			return Task.FromResult(result);
		}

		public Task<bool> IsInRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (string.IsNullOrWhiteSpace(roleName))
				throw new ArgumentNullException(nameof(roleName));

			var result = _userRoleRepository.GetRoleNamesByUserId(user.Id).Any(x => x == roleName);

			return Task.FromResult(result);
		}

		public Task<IList<ApplicationUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (string.IsNullOrWhiteSpace(roleName))
				throw new ArgumentNullException(nameof(roleName));

			IList<ApplicationUser> result = _userRoleRepository.GetUsersByRoleName(roleName)
				.Select(x => GetApplicationUser(x))
				.ToList();

			return Task.FromResult(result);
		}
		#endregion

		#region IUserSecurityStampStore<ApplicationUser> Members
		public Task SetSecurityStampAsync(ApplicationUser user, string stamp, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			user.SecurityStamp = stamp;

			return Task.CompletedTask;
		}

		public Task<string> GetSecurityStampAsync(ApplicationUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			return Task.FromResult(user.SecurityStamp);
		}

		#endregion

		#region IUserClaimStore<ApplicationUser> Members

		public Task<IList<Claim>> GetClaimsAsync(ApplicationUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			IList<Claim> result = _userClaimRepository.GetByUserId(user.Id)
				.Select(x => new Claim(x.ClaimType, x.ClaimValue)).ToList();

			return Task.FromResult(result);
		}

		public Task AddClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (claims == null)
				throw new ArgumentNullException(nameof(claims));

			var claimEntities = claims.Select(x => GetUserClaimEntity(x, user.Id)).ToList();

			if (!claimEntities.Any()) return Task.CompletedTask;

			claimEntities.ForEach(claimEntity =>
			{
				_userClaimRepository.Add(claimEntity);
			});

			return Task.CompletedTask;
		}

		public Task ReplaceClaimAsync(ApplicationUser user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (claim == null)
				throw new ArgumentNullException(nameof(claim));

			if (newClaim == null)
				throw new ArgumentNullException(nameof(newClaim));

			var claimEntity = _userClaimRepository.GetByUserId(user.Id)
				.SingleOrDefault(x => x.ClaimType == claim.Type && x.ClaimValue == claim.Value);

			if (claimEntity == null) return Task.CompletedTask;

			claimEntity.ClaimType = newClaim.Type;
			claimEntity.ClaimValue = newClaim.Value;

			_userClaimRepository.Update(claimEntity);

			return Task.CompletedTask;
		}

		public Task RemoveClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (claims == null)
				throw new ArgumentNullException(nameof(claims));

			var claimsList = claims.ToList();

			if (!claimsList.Any()) return Task.CompletedTask;

			var userClaimEntities = _userClaimRepository.GetByUserId(user.Id);

			claimsList.ForEach(claim =>
			{
				var userClaimEntity = userClaimEntities.SingleOrDefault(x => x.ClaimType == claim.Type && x.ClaimValue == claim.Value);

				if (userClaimEntity != null)
				{
					_userClaimRepository.Remove(userClaimEntity.Id);
				}
			});

			return Task.CompletedTask;
		}

		public Task<IList<ApplicationUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (claim == null)
				throw new ArgumentNullException(nameof(claim));

			IList<ApplicationUser> result = _userClaimRepository.GetUsersForClaim(claim.Type, claim.Value).Select(x => GetApplicationUser(x)).ToList();

			return Task.FromResult(result);
		}

		#endregion

		#region IUserAuthenticationTokenStore<ApplicationUser> Members

		public Task SetTokenAsync(ApplicationUser user, string loginProvider, string name, string value, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (string.IsNullOrWhiteSpace(loginProvider))
				throw new ArgumentNullException(nameof(loginProvider));

			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentNullException(nameof(name));

			var userTokenEntity = new UserToken
			{
				LoginProvider = loginProvider,
				Name = name,
				Value = value,
				UserId = user.Id
			};

			_userTokenRepository.Add(userTokenEntity);

			return Task.CompletedTask;
		}

		public Task RemoveTokenAsync(ApplicationUser user, string loginProvider, string name, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (string.IsNullOrWhiteSpace(loginProvider))
				throw new ArgumentNullException(nameof(loginProvider));

			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentNullException(nameof(name));

			var userTokenEntity = _userTokenRepository.GetById(new UserTokenKey { UserId = user.Id, LoginProvider = loginProvider, Name = name });

			if (userTokenEntity != null)
			{
				_userTokenRepository.Remove(userTokenEntity);
			}

			return Task.CompletedTask;
		}

		public Task<string> GetTokenAsync(ApplicationUser user, string loginProvider, string name, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (string.IsNullOrWhiteSpace(loginProvider))
				throw new ArgumentNullException(nameof(loginProvider));

			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentNullException(nameof(name));

			var userTokenEntity = _userTokenRepository.GetById(new UserTokenKey { UserId = user.Id, LoginProvider = loginProvider, Name = name });

			return Task.FromResult(userTokenEntity?.Name);
		}

		#endregion

		#region IUserTwoFactorStore<ApplicationUser> Members

		public Task SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			user.TwoFactorEnabled = enabled;

			return Task.CompletedTask;
		}

		public Task<bool> GetTwoFactorEnabledAsync(ApplicationUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			return Task.FromResult(user.TwoFactorEnabled);
		}

		#endregion

		#region IUserPhoneNumberStore<ApplicationUser> Members

		public Task SetPhoneNumberAsync(ApplicationUser user, string phoneNumber, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			user.PhoneNumber = phoneNumber;

			return Task.CompletedTask;
		}

		public Task<string> GetPhoneNumberAsync(ApplicationUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			return Task.FromResult(user.PhoneNumber);
		}

		public Task<bool> GetPhoneNumberConfirmedAsync(ApplicationUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			return Task.FromResult(user.PhoneNumberConfirmed);
		}

		public Task SetPhoneNumberConfirmedAsync(ApplicationUser user, bool confirmed, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			user.PhoneNumberConfirmed = confirmed;

			return Task.CompletedTask;
		}

		#endregion

		#region IUserLockoutStore<ApplicationUser> Members

		public Task<DateTimeOffset?> GetLockoutEndDateAsync(ApplicationUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			return Task.FromResult(user.LockoutEnd);
		}

		public Task SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			user.LockoutEnd = lockoutEnd;

			return Task.CompletedTask;
		}

		public Task<int> IncrementAccessFailedCountAsync(ApplicationUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			return Task.FromResult(++user.AccessFailedCount);
		}

		public Task ResetAccessFailedCountAsync(ApplicationUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			user.AccessFailedCount = 0;

			return Task.CompletedTask;
		}

		public Task<int> GetAccessFailedCountAsync(ApplicationUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			return Task.FromResult(user.AccessFailedCount);
		}

		public Task<bool> GetLockoutEnabledAsync(ApplicationUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			return Task.FromResult(user.LockoutEnabled);
		}

		public Task SetLockoutEnabledAsync(ApplicationUser user, bool enabled, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			user.LockoutEnabled = enabled;

			return Task.CompletedTask;
		}

		#endregion

		#region Private Methods

		private static User GetUserEntity(ApplicationUser applicationUser)
		{
			if (applicationUser == null)
				return null;

			var result = new User();
			PopulateUserEntity(result, applicationUser);

			return result;
		}

		private static void PopulateUserEntity(User entity, ApplicationUser applicationUser)
		{
			entity.AccessFailedCount = applicationUser.AccessFailedCount;
			entity.ConcurrencyStamp = applicationUser.ConcurrencyStamp;
			entity.Email = applicationUser.Email;
			entity.EmailConfirmed = applicationUser.EmailConfirmed;
			entity.Id = applicationUser.Id;
			entity.LockoutEnabled = applicationUser.LockoutEnabled;
			entity.LockoutEnd = applicationUser.LockoutEnd;
			entity.NormalizedEmail = applicationUser.NormalizedEmail;
			entity.NormalizedUserName = applicationUser.NormalizedUserName;
			entity.PasswordHash = applicationUser.PasswordHash;
			entity.PhoneNumber = applicationUser.PhoneNumber;
			entity.PhoneNumberConfirmed = applicationUser.PhoneNumberConfirmed;
			entity.SecurityStamp = applicationUser.SecurityStamp;
			entity.TwoFactorEnabled = applicationUser.TwoFactorEnabled;
			entity.UserName = applicationUser.UserName;
		}

		private static ApplicationUser GetApplicationUser(User entity)
		{
			if (entity == null)
				return null;

			var result = new ApplicationUser();
			PopulateApplicationUser(result, entity);

			return result;
		}

		private static void PopulateApplicationUser(ApplicationUser applicationUser, User entity)
		{
			applicationUser.AccessFailedCount = entity.AccessFailedCount;
			applicationUser.ConcurrencyStamp = entity.ConcurrencyStamp;
			applicationUser.Email = entity.Email;
			applicationUser.EmailConfirmed = entity.EmailConfirmed;
			applicationUser.Id = entity.Id;
			applicationUser.LockoutEnabled = entity.LockoutEnabled;
			applicationUser.LockoutEnd = entity.LockoutEnd;
			applicationUser.NormalizedEmail = entity.NormalizedEmail;
			applicationUser.NormalizedUserName = entity.NormalizedUserName;
			applicationUser.PasswordHash = entity.PasswordHash;
			applicationUser.PhoneNumber = entity.PhoneNumber;
			applicationUser.PhoneNumberConfirmed = entity.PhoneNumberConfirmed;
			applicationUser.SecurityStamp = entity.SecurityStamp;
			applicationUser.TwoFactorEnabled = entity.TwoFactorEnabled;
			applicationUser.UserName = entity.UserName;

			//Additional fields of 'PesquisaPreco'
			applicationUser.CreatedOn = entity.CreatedOn;
		}

		private static UserClaim GetUserClaimEntity(Claim value, string userId)
		{
			return value == null
				? default(UserClaim)
				: new UserClaim
				{
					ClaimType = value.Type,
					ClaimValue = value.Value,
					UserId = userId
				};
		}

		#endregion
	}
}
