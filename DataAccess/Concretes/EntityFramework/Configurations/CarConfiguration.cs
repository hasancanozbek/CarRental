using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFramework.Configurations
{
    internal class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(x => x.Deleted).HasDefaultValue(false);
            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.Property(x => x.Price).HasPrecision(9,2);
        }
    }
}
