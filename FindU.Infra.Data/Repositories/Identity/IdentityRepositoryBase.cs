using FindU.Interfaces.Repositories.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FindU.Infra.Data.Repositories.Identity
{
	public class IdentityRepositoryBase<TEntity, TKey> : IIdentityRepositoryBase<TEntity, TKey> where TEntity : class
	{
		protected readonly ApplicationDbContext Context;
		protected readonly DbSet<TEntity> DbSet;

		public IdentityRepositoryBase(ApplicationDbContext context)
		{
			Context = context;
			DbSet = Context.Set<TEntity>();
		}

		public void Add(TEntity obj)
		{
			DbSet.Add(obj);
			SaveChanges();
		}

		public IQueryable<TEntity> GetAll()
		{
			return DbSet;
		}

		public TEntity GetById(TKey id)
		{
			return DbSet.Find(id);
		}

		public void Remove(TKey id)
		{
			var obj = GetById(id);

			DbSet.Remove(obj);
		}

		public void Update(TEntity obj)
		{
			DbSet.Update(obj);
		}

		public int SaveChanges()
		{
			return Context.SaveChanges();
		}

		public void Dispose()
		{
			Context.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
