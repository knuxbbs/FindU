using FindU.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindU.Infra.Data.Mappings.Identity
{
	public class UserTokenMap : IEntityTypeConfiguration<UserToken>
	{
		public void Configure(EntityTypeBuilder<UserToken> builder)
		{
			builder.HasKey("UserId", "LoginProvider", "Name");

			builder.Property<string>("UserId");

			builder.Property<string>("LoginProvider");

			builder.Property<string>("Name");

			builder.Property<string>("Value");

			builder.ToTable("AspNetUserTokens");

			builder.HasOne(typeof(User))
				.WithMany()
				.HasForeignKey("UserId")
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
