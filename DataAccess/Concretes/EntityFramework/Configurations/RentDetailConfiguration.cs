
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

            builder.HasOne(rent => rent.OriginOffice).WithMany(office => office.RentedFromOffice)
                .HasForeignKey(rent => rent.OriginOfficeId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(rent => rent.ReturnOffice).WithMany(office => office.ReturnedToOffice)
                .HasForeignKey(rent => rent.ReturnOfficeId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
