using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mvc.Models.Entities;

namespace Mvc.Data.Configurations
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> b)
        {
            // Primary key
            b.HasKey(uc => uc.Id);

            // Maps to the AspNetUserClaims table
            b.ToTable("UserClaims");
        }
    }
}
