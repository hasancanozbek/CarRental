
using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfCustomerRepository : EfBaseEntityRepository<Customer, AppDbContext>, ICustomerRepository
    {
        public void Delete(int id)
        {
            using (AppDbContext context = new())
            {
                var customerToDeleted = context.Customers.SingleOrDefault(c => c.Id == id);
                context.Remove(customerToDeleted);
                context.SaveChanges();
            }
        }

        public void Update(CustomerDto customer)
        {
            using (AppDbContext context = new())
            {
                var customerToUpdated = context.Customers.SingleOrDefault(c => c.Id == customer.Id);

                customerToUpdated.Telephone = customer.Telephone;
                customerToUpdated.Address = customer.Address;
                customerToUpdated.Email = customer.Email;
                customerToUpdated.Password = customer.Password;

                context.SaveChanges();
            }
        }
    }
}
