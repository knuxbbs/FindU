using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Bogus;
using Bogus.DataSets;
using FindU.Application.Interfaces;
using FindU.Infra.Data.Identity.Configuration;
using FindU.Infra.Data.Identity.Models;
using FindU.Infra.IoC;
using FindU.Models;
using FindU.Models.Joins;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FindU.Application.Test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void ValidarMatriculaTest()
		{
			var curso = new Curso { CodigoSupac = 387 };

			var supacDataImporter = new SupacDataImporter();
			supacDataImporter.ValidarMatricula("215215179", curso);
		}

		[DataRow(10)]
		[DataTestMethod]
		public async Task AdicionarUsuarios(int quantidade)
		{
			var services = new ServiceCollection();

			//É preciso setar arquivo de configuração como "Copy always"
			var config = new ConfigurationBuilder()
				.SetBasePath(AppContext.BaseDirectory)
				.AddJsonFile("appsettings.test.json")
				.Build();

			NativeInjectorBootStrapper.RegisterServicesForTest(services, config.GetConnectionString("DefaultConnection"));

			var serviceProvider = services.BuildServiceProvider();

			var cursoAppService = serviceProvider.GetService<ICursoAppService>();
			var estudanteAppService = serviceProvider.GetService<IEstudanteAppService>();
			var userManager = serviceProvider.GetService<ApplicationUserManager>();

			var cursos = cursoAppService.GetAll().ToArray();
			var orientacoesPoliticas = estudanteAppService.ListarOrientacoesPoliticas().ToArray();
			var tiposConsumoBebida = estudanteAppService.ListarTiposDeConsumoBebida().ToArray();
			var tiposAtracao = estudanteAppService.ListarTiposDeAtracao().ToArray();

			var estudanteFaker = new Faker<Estudante>()
				.RuleFor(x => x.Matricula, y => y.Random.Replace("#########"))
				.RuleFor(x => x.CursoId, y => y.PickRandom(cursos.Select(x => x.Id)))
				.RuleFor(x => x.AnoIngresso, y => y.Date.Past(10).Year)
				.RuleFor(x => x.Genero, y => y.PickRandom<Genero>())
				.RuleFor(x => x.Nome, (f, u) => f.Name.FirstName(GetBogusGender(u.Genero)))
				.RuleFor(x => x.Sobrenome, y => y.Name.LastName())
				.RuleFor(x => x.CaminhoFoto, (f, u) => f.Image.People(GetBogusGender(u.Genero)))
				.RuleFor(x => x.DataNascimento,
					y => y.Date.Between(new DateTime(1980, 01, 01), new DateTime(1990, 01, 01)))
				.RuleFor(x => x.Descricao, y => y.Lorem.Text())
				.RuleFor(x => x.OrientacaoSexual, y => y.PickRandom<OrientacaoSexual>())
				.RuleFor(x => x.OrientacaoPoliticaId, y => y.PickRandom(orientacoesPoliticas.Select(x => x.Id)))
				.RuleFor(x => x.TipoDeConsumoBebidaId, y => y.PickRandom(tiposConsumoBebida.Select(x => x.Id)))
				.RuleFor(x => x.TiposDeAtracao, y => y.Random.ArrayElements(tiposAtracao)
					.Select(tipoDeAtracao => new EstudanteHasTipoDeAtracao
					{
						TipoDeAtracaoId = tipoDeAtracao.Id
					}).ToList());

			var estudantes = estudanteFaker.Generate(quantidade);

			using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
			{
				IList<Action> actions = new List<Action>();

				foreach (var estudante in estudantes)
				{
					ApplicationUser user = null;
					//Task<string> savePhotoTask = null;

					async void Action1()
					{
						var userFaker = new Faker<ApplicationUser>()
							.RuleFor(c => c.UserName, y => y.Internet.Email(estudante.Nome, estudante.Sobrenome, "ufba.br"));

						user = userFaker.Generate();

						//savePhotoTask = Task.Run(() => estudanteAppService.SavePhotoAsync(user.Email, estudante.CaminhoFoto));

						await userManager.CreateAsync(user);
					}

					void Action2()
					{
						estudante.UsuarioId = user.Id;
						estudanteAppService.Add(estudante);
						estudante.CaminhoFoto = $"{estudante.CaminhoFoto}?lock={estudante.Id}";
						//estudante.CaminhoFoto = await savePhotoTask;
					}

					actions.Add(Action1);
					actions.Add(Action2);
				}

				await ForEachAsync(actions);

				estudanteAppService.Update(estudantes);

				scope.Complete();
			}
		}

		private static Name.Gender GetBogusGender(Genero genero)
		{
			return genero == Genero.Masculino ? Name.Gender.Male : Name.Gender.Female;
		}

		private static async Task ForEachAsync(IEnumerable<Action> enumerable)
		{
			foreach (var action in enumerable)
				await Task.Run(() => { action(); }).ConfigureAwait(false);
		}
	}
}
