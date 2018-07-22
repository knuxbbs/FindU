using System;
using System.Linq;

namespace FindU.Interfaces.Repositories.Identity
{
	public interface IIdentityRepositoryBase<TEntity, in TKey> : IDisposable where TEntity : class
	{
		IQueryable<TEntity> GetAll();

		TEntity GetById(TKey key);

		void Add(TEntity entity);

		void Update(TEntity entity);

		void Remove(TKey entity);
	}
}
