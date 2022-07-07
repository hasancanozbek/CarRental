
using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfCarRepository : EfBaseEntityRepository<Car, AppDbContext>, ICarRepository
    {
        public List<CarDto> GetAllCars(Expression<Func<CarDto, bool>> filter = null)
        {
            using (AppDbContext context = new())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join gear in context.GearTypes on car.GearTypeId equals gear.Id
                             join fuel in context.FuelTypes on car.FuelTypeId equals fuel.Id
                             join colour in context.Colours on car.ColourId equals colour.Id
                             select new CarDto
                             {
                                 Id = car.Id,
                                 BrandName = brand.BrandName,
                                 Model = car.Model,
                                 Price = car.Price,
                                 GearType = gear.Gear,
                                 FuelType = fuel.Fuel,
                                 Colour = colour.ColourName
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }

        public CarDto GetCar(Expression<Func<CarDto, bool>> filter)
        {
            using (AppDbContext context = new())
            {
                var result = (from car in context.Cars
                              join brand in context.Brands on car.BrandId equals brand.Id
                              join gear in context.GearTypes on car.GearTypeId equals gear.Id
                              join fuel in context.FuelTypes on car.FuelTypeId equals fuel.Id
                              join colour in context.Colours on car.ColourId equals colour.Id
                              select new CarDto
                              {
                                  Id = car.Id,
                                  BrandName = brand.BrandName,
                                  Model = car.Model,
                                  Price = car.Price,
                                  GearType = gear.Gear,
                                  FuelType = fuel.Fuel,
                                  Colour = colour.ColourName
                              }).SingleOrDefault(filter);
                return result;
            }
        }

        public void Delete(int id)
        {
            using (AppDbContext context = new())
            {
                var carToDeleted = context.Cars.SingleOrDefault(c => c.Id == id);
                carToDeleted.Active = false;
                carToDeleted.Deleted = true;
                context.SaveChanges();
            }
        }

        public void Update(CarUpdateDto car)
        {
            using (AppDbContext context = new())
            {
                var carToUpdated = context.Cars.SingleOrDefault(c => c.Id == car.Id);
                carToUpdated.GearTypeId = car.GearTypeId;
                carToUpdated.FuelTypeId = car.FuelTypeId;
                carToUpdated.ColourId = car.ColourId;
                carToUpdated.Model = car.Model;
                carToUpdated.ModelYear = car.ModelYear;
                carToUpdated.Description = car.Description;
                carToUpdated.Price = car.Price;
                carToUpdated.Active = car.Active;

                context.SaveChanges();
            }
        }

    }
}
