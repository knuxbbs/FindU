using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindU.Infra.Data.Mappings
{
	public class UnidadeUniversitariaMap : IEntityTypeConfiguration<UnidadeUniversitaria>
	{
		public void Configure(EntityTypeBuilder<UnidadeUniversitaria> builder)
		{
			builder.HasKey(c => c.Id);

			builder.Property(c => c.Nome)
				.HasColumnType("varchar(200)")
				.HasMaxLength(100)
				.IsRequired();

			builder.Property(c => c.AreaConhecimentoId)
				.IsRequired();

			builder.HasData(
				new UnidadeUniversitaria { Id = 1, AreaConhecimentoId = 1, Nome = "ARQUITETURA" },
				new UnidadeUniversitaria { Id = 2, AreaConhecimentoId = 1, Nome = "POLITÉCNICA" },
				new UnidadeUniversitaria { Id = 3, AreaConhecimentoId = 1, Nome = "FÍSICA" },
				new UnidadeUniversitaria { Id = 4, AreaConhecimentoId = 1, Nome = "GEOCIÊNCIAS" },
				new UnidadeUniversitaria { Id = 5, AreaConhecimentoId = 1, Nome = "MATEMÁTICA" },
				new UnidadeUniversitaria { Id = 6, AreaConhecimentoId = 1, Nome = "QUIMICA" },

				new UnidadeUniversitaria { Id = 7, AreaConhecimentoId = 2, Nome = "BIOLOGIA" },
				new UnidadeUniversitaria { Id = 8, AreaConhecimentoId = 2, Nome = "ENFERMAGEM" },
				new UnidadeUniversitaria { Id = 9, AreaConhecimentoId = 2, Nome = "FARMÁCIA" },
				new UnidadeUniversitaria { Id = 10, AreaConhecimentoId = 2, Nome = "CIÊNCIAS DA SAÚDE" },
				new UnidadeUniversitaria { Id = 11, AreaConhecimentoId = 2, Nome = "MEDICINA" },
				new UnidadeUniversitaria { Id = 12, AreaConhecimentoId = 2, Nome = "MEDICINA VETERINÁRIA" },
				new UnidadeUniversitaria { Id = 13, AreaConhecimentoId = 2, Nome = "NUTRIÇÃO" },
				new UnidadeUniversitaria { Id = 14, AreaConhecimentoId = 2, Nome = "ODONTOLOGIA" },
				new UnidadeUniversitaria { Id = 15, AreaConhecimentoId = 2, Nome = "SAÚDE COLETIVA" },

				new UnidadeUniversitaria { Id = 16, AreaConhecimentoId = 3, Nome = "ADMINISTRAÇÃO" },
				new UnidadeUniversitaria { Id = 17, AreaConhecimentoId = 3, Nome = "CIÊNCIAS CONTÁBEIS" },
				new UnidadeUniversitaria { Id = 18, AreaConhecimentoId = 3, Nome = "CIÊNCIAS ECONÔMICAS" },
				new UnidadeUniversitaria { Id = 19, AreaConhecimentoId = 3, Nome = "COMUNICAÇÃO" },
				new UnidadeUniversitaria { Id = 20, AreaConhecimentoId = 3, Nome = "DIREITO" },
				new UnidadeUniversitaria { Id = 21, AreaConhecimentoId = 3, Nome = "EDUCAÇÃO" },
				new UnidadeUniversitaria { Id = 22, AreaConhecimentoId = 3, Nome = "FILOSOFIA E CIÊNCIAS HUMANAS" },
				new UnidadeUniversitaria { Id = 23, AreaConhecimentoId = 3, Nome = "PSICOLOGIA" },
				new UnidadeUniversitaria { Id = 24, AreaConhecimentoId = 3, Nome = "CIÊNCIAS DA INFORMAÇÃO" },

				new UnidadeUniversitaria { Id = 25, AreaConhecimentoId = 4, Nome = "LETRAS" },

				new UnidadeUniversitaria { Id = 26, AreaConhecimentoId = 5, Nome = "BELAS ARTES" },
				new UnidadeUniversitaria { Id = 27, AreaConhecimentoId = 5, Nome = "DANÇA" },
				new UnidadeUniversitaria { Id = 28, AreaConhecimentoId = 5, Nome = "MÚSICA" },
				new UnidadeUniversitaria { Id = 29, AreaConhecimentoId = 5, Nome = "TEATRO" },

				new UnidadeUniversitaria { Id = 30, AreaConhecimentoId = 6, Nome = "HUMANIDADES, ARTES E CIÊNCIAS" }
			);
		}
	}
}
