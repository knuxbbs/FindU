using FindU.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindU.Infra.Data.Mappings.Identity
{
	public class RoleClaimMap : IEntityTypeConfiguration<RoleClaim>
	{
		public void Configure(EntityTypeBuilder<RoleClaim> builder)
		{
			builder.HasKey("Id");

			builder.Property<int>("Id")
				.ValueGeneratedOnAdd()
				.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

			builder.Property<string>("ClaimType");

			builder.Property<string>("ClaimValue");

			builder.Property<string>("RoleId")
				.IsRequired();

			builder.HasIndex("RoleId");

			builder.ToTable("AspNetRoleClaims");

			builder.HasOne(typeof(Role))
				.WithMany()
				.HasForeignKey("RoleId")
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
