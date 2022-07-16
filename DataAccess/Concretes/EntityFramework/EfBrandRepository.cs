
using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfBrandRepository : EfBaseEntityRepository<Brand,AppDbContext> , IBrandRepository
    {
        public override void Delete(Brand entity)
        {
            using (AppDbContext context = new())
            {
                var brand = context.Brands.SingleOrDefault(b => b.Id == entity.Id);
                brand.IsDeleted = true;

                context.SaveChanges();
            }
        }
    }
}
