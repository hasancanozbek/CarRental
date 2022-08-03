
using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfEmployeeRepository : EfBaseEntityRepository<Employee, AppDbContext>, IEmployeeRepository
    {
        public void Delete(int id)
        {
            using (AppDbContext context = new())
            {
                var employeToDeleted = context.Employees.SingleOrDefault(e => e.Id == id);
                employeToDeleted.Status = false;
                context.SaveChanges();
            }
        }
    }
}
