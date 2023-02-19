using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mvc.Models.Entities;

namespace Mvc.Data.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("UserRoles");

            builder.HasData(
                new UserRole
                {
                    RoleId = 1,
                    UserId = 1
                },
                new UserRole
                {
                    RoleId = 2,
                    UserId = 2
                },
                new UserRole
                {
                    RoleId = 1,
                    UserId = 3
                });
        }
    }
}
