using FindU.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FindU.Infra.Data.Repositories
{
	public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
	{
		protected readonly ApplicationDbContext Context;
		protected readonly DbSet<TEntity> DbSet;

		public RepositoryBase(ApplicationDbContext context)
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

		public TEntity GetById(int id)
		{
			return DbSet.Find(id);
		}

		public void Remove(TEntity obj)
		{
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
