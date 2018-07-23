using FindU.Application.Interfaces;
using FindU.Interfaces;
using FindU.Models;

namespace FindU.Application.Services
{
	public class CursoAppService : AppServiceBase<Curso>, ICursoAppService
	{
		private readonly ICursoRepository _cursoRepository;

		public CursoAppService(ICursoRepository cursoRepository) : base(cursoRepository)
		{
			_cursoRepository = cursoRepository;
		}
	}
}
