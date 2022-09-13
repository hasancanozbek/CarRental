
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFramework.Configurations
{
    internal class RentDetailConfiguration : IEntityTypeConfiguration<RentDetail>
    {
        public void Configure(EntityTypeBuilder<RentDetail> builder)
        {
            builder.Property(r => r.Price).HasPrecision(9, 2);
        }
    }
}
