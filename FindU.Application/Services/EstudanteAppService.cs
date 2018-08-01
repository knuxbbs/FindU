using System;
using FindU.Application.Interfaces;
using FindU.Interfaces;
using FindU.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Transactions;
using FindU.Application.ViewModels;
using FindU.Application.ViewModels.Identity.AccountViewModels;
using FindU.Infra.Data.Identity.Configuration;
using FindU.Infra.Data.Identity.Models;
using FindU.Models.Joins;
using Microsoft.AspNetCore.Identity;
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
		private readonly ICurtidaRepository _curtidaRepository;
		private readonly IHostingEnvironment _hostingEnvironment;

		public EstudanteAppService(ApplicationUserManager userManager,
			IEstudanteRepository estudanteRepository,
			IOrientacaoPoliticaRepository orientacaoPoliticaRepository,
			ITipoDeAtracaoRepository tipoDeAtracaoRepository,
			ITipoDeConsumoBebidaRepository tipoDeConsumoBebidaRepository,
			ICursoRepository cursoRepository,
			ICurtidaRepository curtidaRepository,
			IHostingEnvironment hostingEnvironment) : base(estudanteRepository)
		{
			_userManager = userManager;
			_estudanteRepository = estudanteRepository;
			_orientacaoPoliticaRepository = orientacaoPoliticaRepository;
			_tipoDeAtracaoRepository = tipoDeAtracaoRepository;
			_tipoDeConsumoBebidaRepository = tipoDeConsumoBebidaRepository;
			_cursoRepository = cursoRepository;
			_curtidaRepository = curtidaRepository;
			_hostingEnvironment = hostingEnvironment;
		}

		public async Task<Estudante> Add(ExternalLoginViewModel model, ExternalLoginInfo info = null)
		{
			Estudante estudante = null;

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
					//var caminhoFoto = SavePhoto(model.Email, model.CaminhoFoto);

					var genero = model.GeneroId == 1 ? Genero.Masculino : Genero.Feminino;
					var generosInteresse = model.GenerosInteresse.Where(x => x.IsChecked).Select(x => x.Text);
					var orientacaoSexual = ObterOrientacaoSexual(genero, generosInteresse.ToArray());

					var estudanteDto = await estudanteDataTask;

					estudante = new Estudante
					{
						Nome = model.Nome,
						Sobrenome = model.Sobrenome,
						CaminhoFoto = model.CaminhoFoto,
						DataNascimento = model.DataNascimento,
						Descricao = model.Sobre,
						Genero = genero,
						OrientacaoSexual = orientacaoSexual,
						OrientacaoPoliticaId = model.OrientacaoPoliticaId == 0 ? null : model.OrientacaoPoliticaId,
						TipoDeConsumoBebidaId = model.TipoDeConsumoBebidaId == 0 ? null : model.TipoDeConsumoBebidaId,
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

					if (info != null)
					{
						await _userManager.AddLoginAsync(user, info);
					}
				}

				scope.Complete();
			}

			return estudante;
		}

		public string SavePhoto(string emailUsuario, string photoUrl)
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

		public async Task<string> SavePhotoAsync(string emailUsuario, string photoUrl)
		{
			//Define diretório para carregamento do arquivo
			var folderPath = Path.Combine(_hostingEnvironment.ContentRootPath, "Uploads", "Users", emailUsuario, "Photos");

			Directory.CreateDirectory(folderPath);

			var filePath = Path.Combine(folderPath, "facebook-profile.jpg");

			using (var httpClient = new HttpClient())
			using (var contentStream = await httpClient.GetStreamAsync(photoUrl))
			using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 1048576, true))
			{
				await contentStream.CopyToAsync(fileStream);
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


		public EstudanteRollViewModel ObterEstudante(ClaimsPrincipal user, EstudanteRollViewModel previousViewModel = null)
		{
			var idUsuario = _userManager.GetUserId(user);
			var estudante = _estudanteRepository.ObterPorUsuario(idUsuario);

			IEnumerable<Estudante> listaEstudantes;

			switch (estudante.OrientacaoSexual)
			{
				case OrientacaoSexual.Hetero:
					listaEstudantes = _estudanteRepository.ListarPorGenero(estudante.Genero == Genero.Masculino
							? Genero.Feminino
							: Genero.Masculino)
						.Where(x => x.OrientacaoSexual == OrientacaoSexual.Bi ||
						            x.OrientacaoSexual == OrientacaoSexual.Hetero);

					break;
				case OrientacaoSexual.Homo:
					listaEstudantes = _estudanteRepository.ListarPorGenero(estudante.Genero)
						.Where(x => x.OrientacaoSexual == OrientacaoSexual.Homo);

					break;
				case OrientacaoSexual.Bi:
					listaEstudantes = _estudanteRepository.GetAll();
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			if (previousViewModel != null)
			{
				listaEstudantes = listaEstudantes.Where(x => !previousViewModel.UsuariosDescartados.Contains(x.UsuarioId));
			}

			var matches = _curtidaRepository.ObterMatchesPorUsuario(idUsuario);

			if (matches != null)
			{
				
			}

			if (!listaEstudantes.Any()) return null;

			var random = new Random();
			var index = random.Next(0, listaEstudantes.Count());
			var estudanteSelecionado = listaEstudantes.ElementAt(index);

			var estudanteRollViewModel = new EstudanteRollViewModel
			{
				CaminhoFoto = estudanteSelecionado.CaminhoFoto,
				Nome = estudanteSelecionado.Nome,
				Idade = DateTime.Now.Year - estudanteSelecionado.DataNascimento.Year,
				Descricao = estudanteSelecionado.Descricao,
				OrientacaoPolitica = estudanteSelecionado.OrientacaoPolitica?.Nome,
				TipoDeConsumoBebida = estudanteSelecionado.TipoDeConsumoBebida?.Nome,
				TiposDeAtracao = estudanteSelecionado.TiposDeAtracao
					.Select(x => x.TipoDeAtracao.Nome).ToArray(),
				AreaConhecimento = estudanteSelecionado.Curso.UnidadeUniversitaria.AreaConhecimento.Nome,
				AnoIngresso = estudanteSelecionado.AnoIngresso,
				UsuarioId = estudanteSelecionado.UsuarioId
			};

			if (previousViewModel != null)
			{
				estudanteRollViewModel.UsuariosDescartados.AddRange(previousViewModel.UsuariosDescartados);
			}

			estudanteRollViewModel.UsuariosDescartados.Add(estudanteRollViewModel.UsuarioId);

			return estudanteRollViewModel;
		}

		public LikeResultViewModel Curtir(ClaimsPrincipal user, string idUsuarioCurtido)
		{
			var idUsuario = _userManager.GetUserId(user);

			var curtida = _curtidaRepository.GetById(idUsuario, idUsuarioCurtido);
			var existeCurtida = curtida != null;

			if (existeCurtida)
			{
				_curtidaRepository.Remove(curtida);
			}
			else
			{
				_curtidaRepository.Add(new Curtida
				{
					UsuarioId = idUsuario,
					UsuarioCurtidoId = idUsuarioCurtido,
					Data = DateTime.Now
				});
			}

			var match = _curtidaRepository.GetById(idUsuarioCurtido, idUsuario);

			var likeResult = new LikeResultViewModel
			{
				Liked = !existeCurtida,
				Match = match != null
			};

			return likeResult;
		}

		public EstudanteDetailsViewModel ObterEstudanteCorrespondido(ClaimsPrincipal user, string idUsuarioCurtido)
		{
			var idUsuario = _userManager.GetUserId(user);

			var match = _curtidaRepository.GetById(idUsuarioCurtido, idUsuario);

			if (match == null) return null;

			var estudante = _estudanteRepository.ObterPorUsuario(idUsuarioCurtido);

			return new EstudanteDetailsViewModel
			{
				Nome = $"{estudante.Nome} {estudante.Sobrenome}",
				Curso = estudante.Curso.Nome,
				PhoneNumber = estudante.Usuario.PhoneNumber,
				UsuarioId = estudante.UsuarioId
			};
		}

		public IEnumerable<EstudanteDetailsViewModel> ListarEstudantesCorrespondidos(ClaimsPrincipal user)
		{
			var idUsuario = _userManager.GetUserId(user);

			var matches = _curtidaRepository.ObterMatchesPorUsuario(idUsuario);

			return matches.Select(match => _estudanteRepository.ObterPorUsuario(match.UsuarioId))
				.Select(estudanteCorrespondido => new EstudanteDetailsViewModel
				{
					Nome = $"{estudanteCorrespondido.Nome} {estudanteCorrespondido.Sobrenome}",
					Curso = estudanteCorrespondido.Curso.Nome,
					PhoneNumber = estudanteCorrespondido.Usuario.PhoneNumber,
					UsuarioId = estudanteCorrespondido.UsuarioId,
					Facebook = $"www.facebook.com/{estudanteCorrespondido.UsuarioId}",
				})
				.ToList();
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
