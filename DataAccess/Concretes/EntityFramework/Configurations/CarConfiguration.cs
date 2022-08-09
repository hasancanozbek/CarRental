using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFramework.Configurations
{
    internal class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(c => c.Deleted).HasDefaultValue(false);
            builder.Property(c => c.Active).HasDefaultValue(true);
            builder.Property(c => c.Price).HasPrecision(9,2);
            //builder.HasIndex(c => c.Model).IsUnique();
        }
    }
}
