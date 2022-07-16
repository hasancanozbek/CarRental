
using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfColourRepository : EfBaseEntityRepository<Colour, AppDbContext>, IColourRepository
    {
        public override void Delete(Colour entity)
        {
            using (AppDbContext context = new())
            {
                var colour = context.Colours.SingleOrDefault(c => c.Id == entity.Id);
                colour.IsDeleted = true;
                context.SaveChanges();
            }
        }
    }
}
