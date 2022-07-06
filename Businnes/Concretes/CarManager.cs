
using Businnes.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;

namespace Businnes.Concretes
{
    public class CarManager : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarManager(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }


        public Result Add(Car car)
        {
            _carRepository.Add(car);
            return new SuccessResult("Car added to database successfully.");
        }

        public Result Delete(Car car)
        {
            _carRepository.Delete(car);
            return new SuccessResult("Car removed from database successfully.");
        }

        public DataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carRepository.GetAll(),"All cars listed.");
        }

        public DataResult<List<Car>> GetAllByFuelType(int fuelId)
        {
            return new SuccessDataResult<List<Car>>(_carRepository.GetAll(c => c.FuelTypeId == fuelId), "Cars with desired fuel type are listed.");
        }

        public DataResult<List<Car>> GetAllByGearType(int gearId)
        {
            return new SuccessDataResult<List<Car>>(_carRepository.GetAll(c => c.GearTypeId == gearId), "Cars with desired gear type are listed.");
        }

        public DataResult<List<Car>> GetAllByYear(int min, int max)
        {
            return new SuccessDataResult<List<Car>>(_carRepository.GetAll(c => c.ModelYear >= min && c.ModelYear <= max), "Cars are listed according to the desired year range.");
        }

        public DataResult<List<CarDto>> GetAllCarInfo()
        {
            // Dto yapısı DataAccess'e yazılacak.
            throw new NotImplementedException();
        }

        public DataResult<List<Car>> GetByColour(int colour)
        {
            return new SuccessDataResult<List<Car>>(_carRepository.GetAll(c => c.ColourId == colour), "Cars with desired colour are listed.");
        }

        public DataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carRepository.Get(c => c.Id == id), "Car information specified by id is listed");
        }

        public DataResult<List<Car>> GetByPrice(int min, int max)
        {
            return new SuccessDataResult<List<Car>>(_carRepository.GetAll(c => c.Price >= min && c.Price <= max), "Cars are listed according to the desired price range.");
        }

        public DataResult<CarDto> GetCarInfo(int id)
        {
            //Dto yapısı DataAccess'e yazılacak.
            throw new NotImplementedException();
        }

        public Result Update(Car car)
        {
            _carRepository.Update(car);
            return new SuccessResult("Car information updated.");
        }
    }
}
