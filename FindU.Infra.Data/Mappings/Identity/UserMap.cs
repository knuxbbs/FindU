using FindU.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindU.Infra.Data.Mappings.Identity
{
	public class UserMap : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(c => c.Id);

			builder.Property(c => c.Id)
				.HasColumnName("Id")
				.ValueGeneratedOnAdd();

			builder.Property(c => c.AccessFailedCount)
				.HasColumnName("AccessFailedCount");

			builder.Property(c => c.ConcurrencyStamp)
				.HasColumnName("ConcurrencyStamp")
				.IsConcurrencyToken();

			builder.Property(c => c.Email)
				.HasColumnName("Email")
				.HasMaxLength(256);

			builder.Property(c => c.EmailConfirmed)
				.HasColumnName("EmailConfirmed");

			builder.Property(c => c.LockoutEnabled)
				.HasColumnName("LockoutEnabled");

			builder.Property(c => c.LockoutEnd)
				.HasColumnName("LockoutEnd");

			builder.Property(c => c.NormalizedEmail)
				.HasColumnName("NormalizedEmail")
				.HasMaxLength(256);

			builder.Property(c => c.NormalizedUserName)
				.HasColumnName("NormalizedUserName")
				.HasMaxLength(256);

			builder.Property(c => c.PasswordHash)
				.HasColumnName("PasswordHash");

			builder.Property(c => c.PhoneNumber)
				.HasColumnName("PhoneNumber");

			builder.Property(c => c.PhoneNumberConfirmed)
				.HasColumnName("PhoneNumberConfirmed");

			builder.Property(c => c.SecurityStamp)
				.HasColumnName("SecurityStamp");

			builder.Property(c => c.TwoFactorEnabled)
				.HasColumnName("TwoFactorEnabled");

			builder.Property(c => c.UserName)
				.HasColumnName("UserName")
				.HasMaxLength(256);

			builder.Property(c => c.CreatedOn)
				.Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;

			builder.HasIndex("NormalizedEmail")
				.HasName("EmailIndex");

			builder.HasIndex("NormalizedUserName")
				.IsUnique()
				.HasName("UserNameIndex")
				.HasFilter("[NormalizedUserName] IS NOT NULL");

			builder.ToTable("AspNetUsers");
		}
	}
}

