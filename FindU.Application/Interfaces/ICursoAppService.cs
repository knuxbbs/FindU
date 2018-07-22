using System.Collections.Generic;

namespace FindU.Application.Interfaces
{
	public interface ICursoAppService : IAppServiceBase<Curso>
	{
		IEnumerable<Curso> Listar();
	}
}
