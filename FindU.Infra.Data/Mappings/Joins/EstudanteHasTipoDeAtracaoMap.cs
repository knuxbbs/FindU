using FindU.Models.Joins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindU.Infra.Data.Mappings.Joins
{
	public class EstudanteHasTipoDeAtracaoMap : IEntityTypeConfiguration<EstudanteHasTipoDeAtracao>
	{
		public void Configure(EntityTypeBuilder<EstudanteHasTipoDeAtracao> builder)
		{
			builder.HasKey(c => new { c.EstudanteId, c.TipoDeAtracaoId });

			builder.HasOne(c => c.Estudante)
				.WithMany(c => c.TiposDeAtracao)
				.HasForeignKey(c => c.EstudanteId)
				.HasConstraintName("FK_EstudanteHasTipoDeAtracao_EstudanteId");

			builder.HasOne(c => c.TipoDeAtracao)
				.WithMany(c => c.Estudantes)
				.HasForeignKey(c => c.TipoDeAtracaoId)
				.HasConstraintName("FK_EstudanteHasTipoDeAtracao_TipoDeAtracaoId");
		}
	}
}
