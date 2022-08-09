
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFramework.Configurations
{
    internal class GearTypeConfiguration : IEntityTypeConfiguration<GearType>
    {
        public void Configure(EntityTypeBuilder<GearType> builder)
        {
            builder.Property(g => g.IsDeleted).HasDefaultValue(false);
            builder.HasIndex(g => g.Gear).IsUnique();
        }
    }
}
