using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFramework.Configurations
{
    internal class ColourConfiguration : IEntityTypeConfiguration<Colour>
    {
        public void Configure(EntityTypeBuilder<Colour> builder)
        {
            builder.Property(c => c.IsDeleted).HasDefaultValue(false);
            builder.HasIndex(c => c.ColourName).IsUnique();
        }
    }
}
