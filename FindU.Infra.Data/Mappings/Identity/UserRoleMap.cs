using FindU.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindU.Infra.Data.Mappings.Identity
{
	public class UserRoleMap : IEntityTypeConfiguration<UserRole>
	{
		public void Configure(EntityTypeBuilder<UserRole> builder)
		{
			builder.HasKey("UserId", "RoleId");

			builder.Property<string>("UserId");

			builder.Property<string>("RoleId");

			builder.HasIndex("RoleId");

			builder.ToTable("AspNetUserRoles");

			builder.HasOne(c => c.Role)
				.WithMany()
				.HasForeignKey(c => c.RoleId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(c => c.User)
				.WithMany()
				.HasForeignKey(c => c.UserId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
