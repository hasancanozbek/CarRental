
using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfFuelTypeRepository : EfBaseEntityRepository<FuelType,AppDbContext> , IFuelTypeRepository
    {
        public override void Delete(FuelType entity)
        {
            using (AppDbContext context = new())
            {
                var fuelType = context.FuelTypes.SingleOrDefault(f => f.Id == entity.Id);
                fuelType.IsDeleted = true;
                context.Cars.Where(c => c.FuelTypeId == fuelType.Id).ToList().ForEach(c =>
                {
                    c.Active = false;
                });
                context.SaveChanges();
            }
        }
    }
}
