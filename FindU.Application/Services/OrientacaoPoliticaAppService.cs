using FindU.Application.Interfaces;
using FindU.Interfaces;

namespace FindU.Application.Services
{
	public class OrientacaoPoliticaAppService : AppServiceBase<OrientacaoPolitica>, IOrientacaoPoliticaAppService
	{
		private readonly IOrientacaoPoliticaRepository _orientacaoPoliticaRepository;

		public OrientacaoPoliticaAppService(IOrientacaoPoliticaRepository orientacaoPoliticaRepository)
			: base(orientacaoPoliticaRepository)
		{
			_orientacaoPoliticaRepository = orientacaoPoliticaRepository;
		}
	}
}
