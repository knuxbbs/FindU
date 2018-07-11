using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindU.Infra.Data.Mappings
{
	class AreaConhecimentoMap : IEntityTypeConfiguration<AreaConhecimento>
	{
		public void Configure(EntityTypeBuilder<AreaConhecimento> builder)
		{
			builder.HasKey(c => c.Id);

			builder.Property(c => c.Nome)
				.HasColumnType("varchar(100)")
				.HasMaxLength(100)
				.IsRequired();

			builder.HasData(
				new AreaConhecimento { Id = 1, Nome = "ÁREA I - Ciências Físicas, Matemática e Tecnologia" },
				new AreaConhecimento { Id = 2, Nome = "ÁREA II - Ciências Biológicas e Profissões da Saúde" },
				new AreaConhecimento { Id = 3, Nome = "ÁREA III - Filosofia e Ciências Humanas" },
				new AreaConhecimento { Id = 4, Nome = "ÁREA IV - Letras" },
				new AreaConhecimento { Id = 5, Nome = "ÁREA V - Artes" },
				new AreaConhecimento { Id = 6, Nome = "Bacharelados Interdisciplinares" }
			);
		}
	}
}
