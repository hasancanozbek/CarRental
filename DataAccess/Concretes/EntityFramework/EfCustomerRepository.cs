
using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;

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

        //Hatalar giderilecek
        public void RentCar(Customer customer, Car car, string originAddress, string? returnAddress)
        {
            using (AppDbContext context = new())
            {
                customer.RentDetails.Add(new RentDetail
                {
                    CarId = car.Id,
                    CustomerId = customer.Id,
                    Price = car.Price,
                    RentalDate = DateTime.UtcNow,
                    ReturnDate = null,
                    OriginAddress = originAddress,
                    ReturnAddress = returnAddress
                });
                car.Active = false;
                context.Cars.Update(car);

                context.SaveChanges();
            }
        }

        public void ReturnCar(Car car)
        {
            using (AppDbContext context = new())
            {
                var rentDetail = car.RentDetails.SingleOrDefault(c => c.CarId == car.Id);
                rentDetail.ReturnDate = DateTime.UtcNow;
                rentDetail.Car.Active = true;
                if (rentDetail.ReturnAddress == null)
                {
                    rentDetail.ReturnAddress = "Şubeden teslim alınmıştır.";
                }
                context.SaveChanges();
            }
        }
    }
}