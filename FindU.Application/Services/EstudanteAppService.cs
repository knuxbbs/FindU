using System;
using FindU.Application.Interfaces;
using FindU.Interfaces;
using FindU.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Transactions;
using FindU.Application.ViewModels.Identity.AccountViewModels;
using FindU.Infra.Data.Identity.Configuration;
using FindU.Infra.Data.Identity.Models;
using FindU.Models.Joins;
using Microsoft.Extensions.Hosting;

namespace FindU.Application.Services
{
	public class EstudanteAppService : AppServiceBase<Estudante>, IEstudanteAppService
	{
		private readonly ApplicationUserManager _userManager;
		private readonly IEstudanteRepository _estudanteRepository;
		private readonly IOrientacaoPoliticaRepository _orientacaoPoliticaRepository;
		private readonly ITipoDeAtracaoRepository _tipoDeAtracaoRepository;
		private readonly ITipoDeConsumoBebidaRepository _tipoDeConsumoBebidaRepository;
		private readonly ICursoRepository _cursoRepository;
		private readonly IHostingEnvironment _hostingEnvironment;

		public EstudanteAppService(ApplicationUserManager userManager,
			IEstudanteRepository estudanteRepository,
			IOrientacaoPoliticaRepository orientacaoPoliticaRepository,
			ITipoDeAtracaoRepository tipoDeAtracaoRepository,
			ITipoDeConsumoBebidaRepository tipoDeConsumoBebidaRepository,
			ICursoRepository cursoRepository,
			IHostingEnvironment hostingEnvironment) : base(estudanteRepository)
		{
			_userManager = userManager;
			_estudanteRepository = estudanteRepository;
			_orientacaoPoliticaRepository = orientacaoPoliticaRepository;
			_tipoDeAtracaoRepository = tipoDeAtracaoRepository;
			_tipoDeConsumoBebidaRepository = tipoDeConsumoBebidaRepository;
			_cursoRepository = cursoRepository;
			_hostingEnvironment = hostingEnvironment;
		}

		public async Task<Estudante> Add(ExternalLoginViewModel model)
		{
			using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
			{
				var curso = _cursoRepository.GetById(model.CursoId);
				var estudanteDataTask = Task.Run(() => SupacDataImporter.ObterDadosDeEstudante(model.Matricula, curso));

				var user = new ApplicationUser
				{
					UserName = model.Email,
					Email = model.Email,
					PhoneNumber = model.PhoneNumber
				};

				var result = await _userManager.CreateAsync(user);

				if (result.Succeeded)
				{
					var caminhoFoto = SavePhoto(model.Email, model.CaminhoFoto);

					var genero = model.GeneroId == 1 ? Genero.Masculino : Genero.Feminino;
					var generosInteresse = model.GenerosInteresse.Where(x => x.IsChecked).Select(x => x.Text);
					var orientacaoSexual = ObterOrientacaoSexual(genero, generosInteresse.ToArray());

					var estudanteDto = await estudanteDataTask;

					var estudante = new Estudante
					{
						Nome = model.Nome,
						Sobrenome = model.Sobrenome,
						CaminhoFoto = caminhoFoto,
						DataNascimento = model.DataNascimento,
						Descricao = model.Sobre,
						Genero = genero,
						OrientacaoSexual = orientacaoSexual,
						OrientacaoPoliticaId = model.OrientacaoPoliticaId,
						TipoDeConsumoBebidaId = model.TipoDeConsumoBebidaId,
						TiposDeAtracao = model.TiposDeAtracao.Where(x => x.IsChecked)
							.Select(tipoDeAtracao => new EstudanteHasTipoDeAtracao
							{
								TipoDeAtracaoId = tipoDeAtracao.Id
							}).ToList(),
						Localizacao = model.Localizacao,
						Matricula = model.Matricula,
						CursoId = model.CursoId,
						AnoIngresso = int.Parse(estudanteDto.Ingresso.Split('-')[0]),
						UsuarioId = user.Id
					};

					Add(estudante);
				}

				scope.Complete();
			}

			return null;
		}

		private string SavePhoto(string emailUsuario, string photoUrl)
		{
			string filePath;

			//Define diretório para carregamento do arquivo
			var folderPath = Path.Combine(_hostingEnvironment.ContentRootPath, "Uploads", "Users", emailUsuario, "Photos");

			Directory.CreateDirectory(folderPath);

			using (var webClient = new WebClient())
			{
				filePath = Path.Combine(folderPath, "facebook-profile.jpg");

				webClient.DownloadFile(photoUrl, filePath);
			}

			return Path.GetRelativePath(_hostingEnvironment.ContentRootPath, filePath);
		}

		private OrientacaoSexual ObterOrientacaoSexual(Genero genero, IReadOnlyCollection<string> generosInteresse)
		{
			if (generosInteresse.Count == 2)
			{
				return OrientacaoSexual.Bi;
			}

			switch (genero)
			{
				case Genero.Masculino when generosInteresse.Contains("Mulheres"):
					return OrientacaoSexual.Hetero;
				case Genero.Masculino when generosInteresse.Contains("Homens"):
					return OrientacaoSexual.Homo;
				case Genero.Feminino when generosInteresse.Contains("Homens"):
					return OrientacaoSexual.Hetero;
				case Genero.Feminino when generosInteresse.Contains("Mulheres"):
					return OrientacaoSexual.Homo;
				default:
					throw new ArgumentOutOfRangeException(nameof(genero), genero, null);
			}
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
