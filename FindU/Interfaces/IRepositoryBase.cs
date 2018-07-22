using System;
using System.Linq;

namespace FindU.Interfaces
{
	public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
	{
		void Add(TEntity obj);
		TEntity GetById(int id);
		IQueryable<TEntity> GetAll();
		void Update(TEntity obj);
		void Remove(TEntity obj);
		int SaveChanges();
	}
}
