using FindU.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindU.Infra.Data.Mappings.Identity
{
	public class RoleMap : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder.HasKey(c => c.Id);

			builder.Property(c => c.Id)
				.ValueGeneratedOnAdd();

			builder.Property(c => c.ConcurrencyStamp)
				.IsConcurrencyToken();

			builder.Property(c => c.Name)
				.HasMaxLength(256);

			builder.Property(c => c.NormalizedName)
				.HasMaxLength(256);

			builder.HasIndex(c => c.NormalizedName)
				.IsUnique()
				.HasName("RoleNameIndex")
				.HasFilter("[NormalizedName] IS NOT NULL");

			builder.ToTable("AspNetRoles");
		}
	}
}
