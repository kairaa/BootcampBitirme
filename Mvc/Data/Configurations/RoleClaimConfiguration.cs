using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mvc.Models.Entities;

namespace Mvc.Data.Configurations
{
    public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> b)
        {
            // Primary key
            b.HasKey(rc => rc.Id);

            // Maps to the AspNetRoleClaims table
            b.ToTable("RoleClaims");
        }
    }
}
