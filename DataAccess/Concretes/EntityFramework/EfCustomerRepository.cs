
using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

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

        public void RentCar(int customerId, int carId, string originAddress, string returnAddress)
        {
            using (AppDbContext context = new())
            {
                var customer = context.Customers.SingleOrDefault(customer => customer.Id == customerId);
                var car = context.Cars.SingleOrDefault(car => car.Id == carId);
                context.RentDetails.Add(new RentDetail()
                {
                    CustomerId = customerId,
                    CarId = carId,
                    Price = car.Price,
                    RentalDate = DateTime.Now,
                    ReturnDate = null,
                    OriginAddress = originAddress,
                    ReturnAddress = returnAddress
                });
                car.Active = false;

                context.SaveChanges();
            }
        }

        public void ReturnCar(int carId)
        {
            using (AppDbContext context = new())
            {
                var car = context.Cars.IgnoreQueryFilters().SingleOrDefault(car => car.Id == carId);
                var rentDetail = context.RentDetails.SingleOrDefault(rentDetail => rentDetail.CarId == carId);
                rentDetail.ReturnDate = DateTime.Now;
                car.Active = true;

                context.SaveChanges();
            }
        }
    }
}