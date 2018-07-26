using FindU.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindU.Infra.Data.Mappings
{
    public class CurtidaMap : IEntityTypeConfiguration<Curtida>
	{
		public void Configure(EntityTypeBuilder<Curtida> builder)
		{
			builder.HasKey(c => new { c.UsuarioId, c.UsuarioCurtidoId });

			builder.HasOne(c => c.Usuario)
				.WithMany()
				.HasForeignKey(c => c.UsuarioId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(c => c.UsuarioCurtido)
				.WithMany()
				.HasForeignKey(c => c.UsuarioCurtidoId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
