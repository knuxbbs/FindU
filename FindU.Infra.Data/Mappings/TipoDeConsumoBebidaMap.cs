using FindU.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindU.Infra.Data.Mappings
{
	public class TipoDeConsumoBebidaMap : IEntityTypeConfiguration<TipoDeConsumoBebida>
	{
		public void Configure(EntityTypeBuilder<TipoDeConsumoBebida> builder)
		{
			builder.HasKey(c => c.Id);

			builder.Property(c => c.Nome)
				.HasColumnType("varchar(200)")
				.HasMaxLength(100)
				.IsRequired();

			var i = 1;

			builder.HasData(
				new TipoDeConsumoBebida { Id = i++, Nome = "Socialmente" },
				new TipoDeConsumoBebida { Id = i++, Nome = "De vez em quando" },
				new TipoDeConsumoBebida { Id = i++, Nome = "Regularmente" },
				new TipoDeConsumoBebida { Id = i++, Nome = "Excessivamente" }
			);
		}
	}
}
