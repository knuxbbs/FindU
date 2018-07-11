using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindU.Infra.Data.Mappings
{
	public class EstudanteMap : IEntityTypeConfiguration<Estudante>
	{
		public void Configure(EntityTypeBuilder<Estudante> builder)
		{
			builder.HasKey(c => c.Id);

			builder.Property(c => c.Nome)
				.HasColumnType("varchar(200)")
				.HasMaxLength(200)
				.IsRequired();

			builder.Property(c => c.CaminhoFoto)
				.IsRequired();

			builder.Property(c => c.DataNascimento)
				.IsRequired();

			builder.Property(c => c.Sobre)
				.IsRequired();

			builder.Property(c => c.Localizacao)
				.HasColumnType("varchar(200)")
				.HasMaxLength(200)
				.IsRequired();

			builder.Property(c => c.Matricula)
				.HasColumnType("varchar(20)")
				.HasMaxLength(20)
				.IsRequired();

			builder.Property(c => c.CursoId)
				.IsRequired();

			builder.Property(c => c.OrientacaoSexualId)
				.IsRequired();
		}
	}
}
