using FindU.Infra.Data.Identity.Models;
using FindU.Infra.Data.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FindU.Infra.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

		public DbSet<Estudante> Estudantes { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
			// Customize the ASP.NET Identity model and override the defaults if needed.
			// For example, you can rename the ASP.NET Identity table names and more.
			// Add your customizations after calling base.OnModelCreating(builder);

			builder.ApplyConfiguration(new EstudanteMap());
			builder.ApplyConfiguration(new AreaConhecimentoMap());
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// get the configuration from the app settings
			var config = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			// define the database to use
			optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
		}
	}
}
