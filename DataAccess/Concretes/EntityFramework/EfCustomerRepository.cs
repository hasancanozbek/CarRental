
using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
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
                customerToDeleted.Status = false;
                context.SaveChanges();
            }
        }

        public RentInformationDto RentCar(int customerId, int carId, int originOffice, int returnOffice)
        {
            using (AppDbContext context = new())
            {
                var car = context.Cars.SingleOrDefault(car => car.Id == carId);
                var brand = context.Brands.SingleOrDefault(b => b.Id == car.BrandId);
                var customer = context.Customers.SingleOrDefault(c => c.Id == customerId);
                var rentDetailData = context.RentDetails.Add(new RentDetail()
                {
                    CustomerId = customerId,
                    CarId = carId,
                    Price = car.Price,
                    RentalDate = DateTime.Now,
                    ReturnDate = null,
                    OriginOfficeId = originOffice,
                    ReturnOfficeId = returnOffice
                });
                RentInformationDto rentInformation = new RentInformationDto
                {
                    Id = rentDetailData.Entity.Id,
                    Car = $"{brand.BrandName} {car.Model}",
                    Price = rentDetailData.Entity.Price,
                    CustomerEmail = customer.Email,
                    CustomerFullName = $"{customer.FirstName} {customer.LastName}",
                    RentalDate = rentDetailData.Entity.RentalDate
                };

                car.Active = false;
     
                context.SaveChanges();
                return rentInformation;
            }
        }

        public void ReturnCar(int carId)
        {
            using (AppDbContext context = new())
            {
                var car = context.Cars.IgnoreQueryFilters().SingleOrDefault(car => car.Id == carId);
                var rentDetail = context.RentDetails.SingleOrDefault(rentDetail => rentDetail.CarId == carId && rentDetail.ReturnDate == null);
                rentDetail.ReturnDate = DateTime.Now;
                car.Active = true;

                context.SaveChanges();
            }
        }
    }
}