using FindU.Application.Interfaces;
using FindU.Interfaces;
using FindU.Models;
using System.Collections.Generic;

namespace FindU.Application.Services
{
	public class EstudanteAppService : AppServiceBase<Estudante>, IEstudanteAppService
	{
		private readonly IEstudanteRepository _estudanteRepository;
		private readonly IOrientacaoPoliticaRepository _orientacaoPoliticaRepository;
		private readonly ITipoDeAtracaoRepository _tipoDeAtracaoRepository;
		private readonly ITipoDeConsumoBebidaRepository _tipoDeConsumoBebidaRepository;

		public EstudanteAppService(IEstudanteRepository estudanteRepository,
			IOrientacaoPoliticaRepository orientacaoPoliticaRepository,
			ITipoDeAtracaoRepository tipoDeAtracaoRepository,
			ITipoDeConsumoBebidaRepository tipoDeConsumoBebidaRepository) : base(estudanteRepository)
		{
			_estudanteRepository = estudanteRepository;
			_orientacaoPoliticaRepository = orientacaoPoliticaRepository;
			_tipoDeAtracaoRepository = tipoDeAtracaoRepository;
			_tipoDeConsumoBebidaRepository = tipoDeConsumoBebidaRepository;
		}

		public IEnumerable<OrientacaoPolitica> ListarOrientacoesPoliticas()
		{
			return _orientacaoPoliticaRepository.GetAll();
		}

		public IEnumerable<TipoDeAtracao> ListarTiposDeAtracao()
		{
			return _tipoDeAtracaoRepository.GetAll();
		}

		public IEnumerable<TipoDeConsumoBebida> ListarTiposDeConsumoBebida()
		{
			return _tipoDeConsumoBebidaRepository.GetAll();
		}
	}
}
