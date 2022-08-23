
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfRentDetailRepository : EfBaseEntityRepository<RentDetail, AppDbContext>, IRentDetailRepository
    {
        public List<RentInformationDto> GetAllRentDetails(Expression<Func<RentInformationDto, bool>> filter = null)
        {

            using (AppDbContext context = new())
            {
                var result = from rentDetail in context.RentDetails
                    join customer in context.Customers on rentDetail.CustomerId equals customer.Id
                    join car in context.Cars on rentDetail.CarId equals car.Id
                    join brand in context.Brands on car.BrandId equals brand.Id
                    select new RentInformationDto
                    {
                        Id = rentDetail.Id,
                        Car = $"{brand.BrandName} {car.Model}",
                        CustomerEmail = customer.Email,
                        CustomerFullName = $"{customer.FirstName} {customer.LastName}",
                        Price = rentDetail.Price,
                        RentalDate = rentDetail.RentalDate
                    };
                return filter == null ? result.IgnoreQueryFilters().ToList() : result.IgnoreQueryFilters().Where(filter).ToList();
            }
        }

        public RentInformationDto GetRentDetail(Expression<Func<RentInformationDto, bool>> filter)
        {
            using (AppDbContext context = new())
            {
                var result = (from rentDetail in context.RentDetails
                    join customer in context.Customers on rentDetail.CustomerId equals customer.Id
                    join car in context.Cars on rentDetail.CarId equals car.Id
                    join brand in context.Brands on car.BrandId equals brand.Id
                    select new RentInformationDto
                    {
                        Id = rentDetail.Id,
                        Car = $"{brand.BrandName} {car.Model}",
                        CustomerEmail = customer.Email,
                        CustomerFullName = $"{customer.FirstName} {customer.LastName}",
                        Price = rentDetail.Price,
                        RentalDate = rentDetail.RentalDate
                    }).IgnoreQueryFilters().SingleOrDefault(filter);
                return result;
            }
        }
    }
}
