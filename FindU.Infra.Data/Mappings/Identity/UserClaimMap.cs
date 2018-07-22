using FindU.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindU.Infra.Data.Mappings.Identity
{
	public class UserClaimMap : IEntityTypeConfiguration<UserClaim>
	{
		public void Configure(EntityTypeBuilder<UserClaim> builder)
		{
			builder.HasKey("Id");

			builder.Property<int>("Id")
				.ValueGeneratedOnAdd()
				.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

			builder.Property<string>("ClaimType");

			builder.Property<string>("ClaimValue");

			builder.Property<string>("UserId")
				.IsRequired();

			builder.HasIndex("UserId");

			builder.ToTable("AspNetUserClaims");

			builder.HasOne(typeof(User))
				.WithMany()
				.HasForeignKey("UserId")
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
