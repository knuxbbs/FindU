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

			var i = 1;

			builder.HasData(
				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 1, Nome = "ARQUITETURA" },
				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 1, Nome = "POLITÉCNICA" },
				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 1, Nome = "FÍSICA" },
				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 1, Nome = "GEOCIÊNCIAS" },
				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 1, Nome = "MATEMÁTICA" },
				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 1, Nome = "QUIMICA" },

				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 2, Nome = "BIOLOGIA" },
				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 2, Nome = "ENFERMAGEM" },
				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 2, Nome = "FARMÁCIA" },
				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 2, Nome = "CIÊNCIAS DA SAÚDE" },
				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 2, Nome = "MEDICINA" },
				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 2, Nome = "MEDICINA VETERINÁRIA" },
				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 2, Nome = "NUTRIÇÃO" },
				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 2, Nome = "ODONTOLOGIA" },
				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 2, Nome = "SAÚDE COLETIVA" },

				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 3, Nome = "ADMINISTRAÇÃO" },
				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 3, Nome = "CIÊNCIAS CONTÁBEIS" },
				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 3, Nome = "CIÊNCIAS ECONÔMICAS" },
				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 3, Nome = "COMUNICAÇÃO" },
				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 3, Nome = "DIREITO" },
				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 3, Nome = "EDUCAÇÃO" },
				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 3, Nome = "FILOSOFIA E CIÊNCIAS HUMANAS" },
				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 3, Nome = "PSICOLOGIA" },
				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 3, Nome = "CIÊNCIAS DA INFORMAÇÃO" },

				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 4, Nome = "LETRAS" },

				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 5, Nome = "BELAS ARTES" },
				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 5, Nome = "DANÇA" },
				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 5, Nome = "MÚSICA" },
				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 5, Nome = "TEATRO" },

				new UnidadeUniversitaria { Id = i++, AreaConhecimentoId = 6, Nome = "HUMANIDADES, ARTES E CIÊNCIAS" }
			);
		}
	}
}
