using System.Linq;

namespace FindU.Application.Interfaces
{
	public interface IAppServiceBase<TEntity> where TEntity : class
	{
		void Add(TEntity obj);
		TEntity GetById(int id);
		IQueryable<TEntity> GetAll();
		void Update(TEntity obj);
		void Remove(TEntity obj);
		int SaveChanges();
	}
}
