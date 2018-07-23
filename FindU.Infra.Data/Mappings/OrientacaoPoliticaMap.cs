using FindU.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindU.Infra.Data.Mappings
{
	public class OrientacaoPoliticaMap : IEntityTypeConfiguration<OrientacaoPolitica>
	{
		public void Configure(EntityTypeBuilder<OrientacaoPolitica> builder)
		{
			builder.HasKey(c => c.Id);

			builder.Property(c => c.Nome)
				.HasColumnType("varchar(100)")
				.HasMaxLength(100)
				.IsRequired();

			builder.HasData(
				new OrientacaoPolitica { Id = 1, Nome = "Conservador de direita" },
				new OrientacaoPolitica { Id = 2, Nome = "Muito conservador, de direita" },
				new OrientacaoPolitica { Id = 3, Nome = "Centrista" },
				new OrientacaoPolitica { Id = 4, Nome = "Esquerda-liberal" },
				new OrientacaoPolitica { Id = 5, Nome = "Muito liberal, de esquerda" },
				new OrientacaoPolitica { Id = 6, Nome = "Libertário" },
				new OrientacaoPolitica { Id = 7, Nome = "Libertário ao extremo" },
				new OrientacaoPolitica { Id = 8, Nome = "Autoritário" },
				new OrientacaoPolitica { Id = 9, Nome = "Autoritário ao extremo" },
				new OrientacaoPolitica { Id = 10, Nome = "Depende" }
			);
		}
	}
}
