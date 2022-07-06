
using Core.Utilities.Results;
using Entities.Concretes;
using Entities.DTOs;

namespace Businnes.Abstracts
{
    public interface ICarService
    {
        Result Add(Car car);
        Result Delete(Car car);
        Result Update(Car car);
        DataResult<Car> GetById(int id);
        DataResult<List<Car>> GetAll();
        DataResult<List<Car>> GetByPrice(int min, int max);
        DataResult<List<Car>> GetAllByGearType(int gearId);
        DataResult<List<Car>> GetAllByFuelType(int fuelId);
        DataResult<CarDto> GetCarInfo(int id);
        DataResult<List<CarDto>> GetAllCarInfo();
        DataResult<List<Car>> GetByColour(int colour);
        DataResult<List<Car>> GetAllByYear(int min, int max);
    }
}
