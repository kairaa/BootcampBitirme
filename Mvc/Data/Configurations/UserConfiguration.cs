using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mvc.Models.Entities;

namespace Mvc.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(u => u.NormalizedUserName).HasDatabaseName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasDatabaseName("EmailIndex");

            // Maps to the AspNetUsers table
            builder.ToTable("Users");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.UserName).HasMaxLength(50);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(50);
            builder.Property(u => u.Email).HasMaxLength(100);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(100);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            builder.HasMany<UserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            builder.HasMany<UserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            builder.HasMany<UserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

            var adminUser = new User
            {
                Id = 1,
                UserName = "admin@mail.com",
                NormalizedUserName = "ADMIN@MAIL.COM",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                FirstName = "Admin",
                LastName = "Admin",
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var normalUser = new User
            {
                Id = 2,
                UserName = "user@mail.com",
                NormalizedUserName = "USER@MAIL.COM",
                Email = "user@mail.com",
                NormalizedEmail = "USER@MAIL.COM",
                FirstName = "User",
                LastName = "User",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var adminUser2 = new User
            {
                Id = 3,
                UserName = "admin2@mail.com",
                NormalizedUserName = "ADMIN2@MAIL.COM",
                Email = "admin2@mail.com",
                NormalizedEmail = "ADMIN2@MAIL.COM",
                FirstName = "Admin2",
                LastName = "Admin2",
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            adminUser2.PasswordHash = CreatePasswordHash(adminUser2, "admin2Password!");

            adminUser.PasswordHash = CreatePasswordHash(adminUser, "Adm1nPassword.");
            normalUser.PasswordHash = CreatePasswordHash(normalUser, "Us3rPassword.");
            builder.HasData(adminUser, normalUser, adminUser2);
        }

        private string CreatePasswordHash(User user, string password)
        {
            var passwordHasher = new PasswordHasher<User>();
            return passwordHasher.HashPassword(user, password);
        }
    }
}
