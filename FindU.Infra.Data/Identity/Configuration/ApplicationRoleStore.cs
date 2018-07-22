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
	public class ApplicationRoleStore : IRoleClaimStore<ApplicationRole>
	{
		private readonly IRoleRepository _roleRepository;
		private readonly IRoleClaimRepository _roleClaimRepository;

		public ApplicationRoleStore(IRoleRepository roleRepository, IRoleClaimRepository roleClaimRepository)
		{
			_roleRepository = roleRepository;
			_roleClaimRepository = roleClaimRepository;
		}

		#region IRoleStore<ApplicationRole> Members

		public Task<IdentityResult> CreateAsync(ApplicationRole role, CancellationToken cancellationToken)
		{
			try
			{
				cancellationToken.ThrowIfCancellationRequested();

				if (role == null)
					throw new ArgumentNullException(nameof(role));

				var roleEntity = GetRoleEntity(role);

				_roleRepository.Add(roleEntity);

				return Task.FromResult(IdentityResult.Success);
			}
			catch (Exception ex)
			{
				return Task.FromResult(IdentityResult.Failed(new IdentityError { Code = ex.Message, Description = ex.Message }));
			}
		}

		public Task<IdentityResult> DeleteAsync(ApplicationRole role, CancellationToken cancellationToken)
		{
			try
			{
				cancellationToken.ThrowIfCancellationRequested();

				if (role == null)
					throw new ArgumentNullException(nameof(role));

				var roleEntity = GetRoleEntity(role);

				_roleRepository.Remove(roleEntity.Id);

				return Task.FromResult(IdentityResult.Success);
			}
			catch (Exception ex)
			{
				return Task.FromResult(IdentityResult.Failed(new IdentityError { Code = ex.Message, Description = ex.Message }));
			}
		}

		public Task<ApplicationRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (string.IsNullOrWhiteSpace(roleId))
				throw new ArgumentNullException(nameof(roleId));

			if (!Guid.TryParse(roleId, out var id))
				throw new ArgumentOutOfRangeException(nameof(roleId), $"{nameof(roleId)} is not a valid GUID");

			var roleEntity = _roleRepository.GetById(id.ToString());
			return Task.FromResult(GetApplicationRole(roleEntity));
		}

		public Task<ApplicationRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (string.IsNullOrWhiteSpace(normalizedRoleName))
				throw new ArgumentNullException(nameof(normalizedRoleName));

			var roleEntity = _roleRepository.FindByName(normalizedRoleName);
			return Task.FromResult(GetApplicationRole(roleEntity));
		}

		public Task<string> GetNormalizedRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (role == null)
				throw new ArgumentNullException(nameof(role));

			return Task.FromResult(role.NormalizedName);
		}

		public Task<string> GetRoleIdAsync(ApplicationRole role, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (role == null)
				throw new ArgumentNullException(nameof(role));

			return Task.FromResult(role.Id);
		}

		public Task<string> GetRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (role == null)
				throw new ArgumentNullException(nameof(role));

			return Task.FromResult(role.Name);
		}

		public Task SetNormalizedRoleNameAsync(ApplicationRole role, string normalizedName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (role == null)
				throw new ArgumentNullException(nameof(role));

			role.NormalizedName = normalizedName;

			return Task.CompletedTask;
		}

		public Task SetRoleNameAsync(ApplicationRole role, string roleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (role == null)
				throw new ArgumentNullException(nameof(role));

			role.Name = roleName;

			return Task.CompletedTask;
		}

		public Task<IdentityResult> UpdateAsync(ApplicationRole role, CancellationToken cancellationToken)
		{
			try
			{
				cancellationToken.ThrowIfCancellationRequested();

				if (role == null)
					throw new ArgumentNullException(nameof(role));

				var roleEntity = GetRoleEntity(role);

				_roleRepository.Update(roleEntity);

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

		#region IRoleClaimStore<ApplicationRole> Members
		public Task<IList<Claim>> GetClaimsAsync(ApplicationRole role, CancellationToken cancellationToken = default(CancellationToken))
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (role == null)
				throw new ArgumentNullException(nameof(role));

			IList<Claim> result = _roleClaimRepository.FindByRoleId(role.Id).Select(x => new Claim(x.ClaimType, x.ClaimValue)).ToList();

			return Task.FromResult(result);
		}

		public Task AddClaimAsync(ApplicationRole role, Claim claim, CancellationToken cancellationToken = default(CancellationToken))
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (role == null)
				throw new ArgumentNullException(nameof(role));

			if (claim == null)
				throw new ArgumentNullException(nameof(claim));

			var roleClaimEntity = new RoleClaim
			{
				ClaimType = claim.Type,
				ClaimValue = claim.Value,
				RoleId = role.Id
			};

			_roleClaimRepository.Add(roleClaimEntity);

			return Task.CompletedTask;
		}

		public Task RemoveClaimAsync(ApplicationRole role, Claim claim, CancellationToken cancellationToken = default(CancellationToken))
		{
			cancellationToken.ThrowIfCancellationRequested();

			if (role == null)
				throw new ArgumentNullException(nameof(role));

			if (claim == null)
				throw new ArgumentNullException(nameof(claim));

			var roleClaimEntity = _roleClaimRepository.FindByRoleId(role.Id)
				.SingleOrDefault(x => x.ClaimType == claim.Type && x.ClaimValue == claim.Value);

			if (roleClaimEntity == null) return Task.CompletedTask;

			_roleClaimRepository.Remove(roleClaimEntity.Id);

			return Task.CompletedTask;
		}
		#endregion

		#region Private Methods

		private static Role GetRoleEntity(ApplicationRole value)
		{
			return value == null
				? default(Role)
				: new Role
				{
					ConcurrencyStamp = value.ConcurrencyStamp,
					Id = value.Id,
					Name = value.Name,
					NormalizedName = value.NormalizedName
				};
		}

		private static ApplicationRole GetApplicationRole(Role value)
		{
			return value == null
				? default(ApplicationRole)
				: new ApplicationRole
				{
					ConcurrencyStamp = value.ConcurrencyStamp,
					Id = value.Id,
					Name = value.Name,
					NormalizedName = value.NormalizedName
				};
		}

		#endregion

	}
}