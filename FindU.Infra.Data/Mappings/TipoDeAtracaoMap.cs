using FindU.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindU.Infra.Data.Mappings
{
	public class TipoDeAtracaoMap : IEntityTypeConfiguration<TipoDeAtracao>
	{
		public void Configure(EntityTypeBuilder<TipoDeAtracao> builder)
		{
			builder.HasKey(c => c.Id);

			builder.Property(c => c.Nome)
				.HasColumnType("varchar(100)")
				.HasMaxLength(100)
				.IsRequired();

			var i = 1;

			builder.HasData(
				new TipoDeAtracao { Id = i++, Nome = "Convicção" },
				new TipoDeAtracao { Id = i++, Nome = "Luz de velas" },
				new TipoDeAtracao { Id = i++, Nome = "Material erótico" },
				new TipoDeAtracao { Id = i++, Nome = "Inteligência" },
				new TipoDeAtracao { Id = i++, Nome = "Demonstrações públicas de afeto" },
				new TipoDeAtracao { Id = i++, Nome = "Sarcasmo" },
				new TipoDeAtracao { Id = i++, Nome = "Tatuagens" },
				new TipoDeAtracao { Id = i++, Nome = "Tempestades" },
				new TipoDeAtracao { Id = i++, Nome = "Piercing(s)" },
				new TipoDeAtracao { Id = i++, Nome = "Dançar" },
				new TipoDeAtracao { Id = i++, Nome = "Flertar" },
				new TipoDeAtracao { Id = i++, Nome = "Cabelos compridos" },
				new TipoDeAtracao { Id = i++, Nome = "Poder" },
				new TipoDeAtracao { Id = i++, Nome = "Nadar nu" },
				new TipoDeAtracao { Id = i++, Nome = "Aventura" },
				new TipoDeAtracao { Id = i++, Nome = "Riqueza material" }
			);
		}
	}
}
