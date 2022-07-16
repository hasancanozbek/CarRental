
using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfGearTypeRepository : EfBaseEntityRepository<GearType, AppDbContext>, IGearTypeRepository
    {
        public override void Delete(GearType entity)
        {
            using (AppDbContext context = new())
            {
                var gearType = context.GearTypes.SingleOrDefault(g => g.Id == entity.Id);
                gearType.IsDeleted = true;
                context.SaveChanges();
            }
        }
    }
}
