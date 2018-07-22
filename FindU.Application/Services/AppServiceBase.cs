using FindU.Application.Interfaces;
using FindU.Interfaces;
using System.Linq;

namespace FindU.Application.Services
{
	public class AppServiceBase<TEntity> : IAppServiceBase<TEntity> where TEntity : class
	{
		private readonly IRepositoryBase<TEntity> _repositoryBase;

		public AppServiceBase(IRepositoryBase<TEntity> repositoryBase)
		{
			_repositoryBase = repositoryBase;
		}

		public void Add(TEntity obj)
		{
			_repositoryBase.Add(obj);
		}

		public IQueryable<TEntity> GetAll()
		{
			return _repositoryBase.GetAll();
		}

		public TEntity GetById(int id)
		{
			return _repositoryBase.GetById(id);
		}

		public void Remove(TEntity obj)
		{
			_repositoryBase.Remove(obj);
		}

		public int SaveChanges()
		{
			return _repositoryBase.SaveChanges();
		}

		public void Update(TEntity obj)
		{
			_repositoryBase.Update(obj);
		}
	}
}
