
using AutoMapper;
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
        private readonly IMapper _mapper;
        public CarManager(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }


        public Result Add(CarAddDto car)
        {
            if(car.Model.Length > 2 && car.Price >= 0)
            {
                var carToAdded = _mapper.Map<Car>(car);
                _carRepository.Add(carToAdded);
                return new SuccessResult("Car added to database successfully.");
            }
            return new ErrorResult("Given car informations is invalid. Try again.");
        }

        public Result Delete(int id)
        {
            _carRepository.Delete(id);
            return new SuccessResult("Car removed from database successfully.");
        }

        public DataResult<List<CarDto>> GetAll()
        {
            var cars = _carRepository.GetAllCars();
            return new SuccessDataResult<List<CarDto>>(cars,"All cars listed.");
        }

        public DataResult<List<CarFeatureDto>> GetAllByBrand(int brandId)
        {
            var cars = _carRepository.GetAll(c => c.BrandId == brandId);
            var carDtos = _mapper.Map<List<CarFeatureDto>>(cars);
            return new SuccessDataResult<List<CarFeatureDto>>(carDtos, "Cars of the desired brand are listed.");
        }

        public DataResult<List<CarFeatureDto>> GetAllByFuelType(int fuelId)
        {
            var cars = _carRepository.GetAll(c => c.FuelTypeId == fuelId);
            var carDtos = _mapper.Map<List<CarFeatureDto>>(cars);
            return new SuccessDataResult<List<CarFeatureDto>>(carDtos, "Cars with desired fuel type are listed.");
        }

        public DataResult<List<CarFeatureDto>> GetAllByGearType(int gearId)
        {
            var cars = _carRepository.GetAll(c => c.GearTypeId == gearId);
            var carDtos = _mapper.Map<List<CarFeatureDto>>(cars);
            return new SuccessDataResult<List<CarFeatureDto>>(carDtos, "Cars with desired gear type are listed.");
        }

        public DataResult<List<CarFeatureDto>> GetAllByYear(int min, int max)
        {
            var cars = _carRepository.GetAll(c => c.ModelYear >= min && c.ModelYear <= max);
            var carDtos = _mapper.Map<List<CarFeatureDto>>(cars);
            return new SuccessDataResult<List<CarFeatureDto>>(carDtos, "Cars are listed according to the desired year range.");
        }

        public DataResult<List<CarFeatureDto>> GetByColour(int colour)
        {
            var cars = _carRepository.GetAll(c => c.ColourId == colour);
            var carDtos = _mapper.Map<List<CarFeatureDto>>(cars);
            return new SuccessDataResult<List<CarFeatureDto>>(carDtos, "Cars with desired colour are listed.");
        }

        public DataResult<CarDto> GetById(int id)
        {
            var car = _carRepository.GetCar(c => c.Id == id);
            return new SuccessDataResult<CarDto>(car, "Car information specified by id is listed.");
        }

        public DataResult<List<CarFeatureDto>> GetByPrice(int min, int max)
        {
            var cars = _carRepository.GetAll(c => c.Price >= min && c.Price <= max);
            var carDtos = _mapper.Map<List<CarFeatureDto>>(cars);
            return new SuccessDataResult<List<CarFeatureDto>>(carDtos, "Cars are listed according to the desired price range.");
        }

        public Result Update(CarUpdateDto car)
        {
            _carRepository.Update(car);
            return new SuccessResult("Car information updated.");
        }
    }
}
