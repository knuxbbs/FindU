using FindU.Infra.Data.Mappings;
using FindU.Infra.Data.Mappings.Identity;
using FindU.Infra.Data.Mappings.Joins;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using FindU.Models;

namespace FindU.Infra.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Estudante> Estudante { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			//Aplica configurações setadas através da FluentAPI

			#region [ Identity ]

			builder.ApplyConfiguration(new UserMap());
			builder.ApplyConfiguration(new RoleMap());
			builder.ApplyConfiguration(new RoleClaimMap());
			builder.ApplyConfiguration(new UserClaimMap());
			builder.ApplyConfiguration(new UserLoginMap());
			builder.ApplyConfiguration(new UserRoleMap());
			builder.ApplyConfiguration(new UserTokenMap());

			#endregion

			builder.ApplyConfiguration(new AreaConhecimentoMap());
			builder.ApplyConfiguration(new UnidadeUniversitariaMap());
			builder.ApplyConfiguration(new CursoMap());
			builder.ApplyConfiguration(new OrientacaoPoliticaMap());
			builder.ApplyConfiguration(new TipoDeConsumoBebidaMap());
			builder.ApplyConfiguration(new TipoDeAtracaoMap());
			builder.ApplyConfiguration(new EstudanteHasTipoDeAtracaoMap());
			builder.ApplyConfiguration(new EstudanteMap());
		}

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	// get the configuration from the app settings
		//	var config = new ConfigurationBuilder()
		//		.SetBasePath(Directory.GetCurrentDirectory())
		//		.AddJsonFile("appsettings.json")
		//		.Build();

		//	// define the database to use
		//	optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
		//}
	}
}
