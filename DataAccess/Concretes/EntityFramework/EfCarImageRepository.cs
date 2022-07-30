
using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfCarImageRepository : EfBaseEntityRepository<CarImage, AppDbContext> ,ICarImageRepository
    {
        public void Delete(int id)
        {
            using (AppDbContext context = new())
            {
                CarImage image = context.CarImages.SingleOrDefault(image => image.Id == id);
                context.Remove(image);
                context.SaveChanges();
            }
        }
    }
}
