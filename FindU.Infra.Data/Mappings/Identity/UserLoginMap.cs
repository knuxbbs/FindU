using FindU.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindU.Infra.Data.Mappings.Identity
{
	public class UserLoginMap : IEntityTypeConfiguration<UserLogin>
	{
		public void Configure(EntityTypeBuilder<UserLogin> builder)
		{
			builder.HasKey("LoginProvider", "ProviderKey");

			builder.Property<string>("LoginProvider");

			builder.Property<string>("ProviderKey");

			builder.Property<string>("ProviderDisplayName");

			builder.Property<string>("UserId")
				.IsRequired();

			builder.HasIndex("UserId");

			builder.ToTable("AspNetUserLogins");

			builder.HasOne(typeof(User))
				.WithMany()
				.HasForeignKey("UserId")
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
