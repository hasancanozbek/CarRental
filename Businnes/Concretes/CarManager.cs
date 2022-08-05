
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;

namespace Business.Concretes
{
    public class CarManager : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarImageService _carImageService;
        private readonly IMapper _mapper;
        public CarManager(ICarRepository carRepository, IMapper mapper, ICarImageService carImageService)
        {
            _carRepository = carRepository;
            _mapper = mapper;
            _carImageService = carImageService;
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin")]
        public Result Add(CarFeatureDto car)
        {
            Result result = BusinessRules.Run(
                CheckCarModelExist(car.Model), CheckForbiddenBrand(car.BrandId));
            if (result != null)
            {
                return result;
            }
            var carToAdded = _mapper.Map<Car>(car);
            _carRepository.Add(carToAdded);
            _carImageService.AddDefaultImage(carToAdded.Id);
            return new SuccessResult("Car added to database successfully.");
        }

        public Result Delete(int id)
        {
            _carRepository.Delete(id);
            return new SuccessResult("Car removed from database successfully.");
        }

        [CacheAspect]
        public DataResult<List<CarDto>> GetAll()
        {
            var cars = _carRepository.GetAllCars();
            return new SuccessDataResult<List<CarDto>>(cars, "All cars listed.");
        }

        [CacheAspect]
        public DataResult<List<CarFeatureDto>> GetAllByBrand(int brandId)
        {
            var cars = _carRepository.GetAll(c => c.BrandId == brandId);
            var carDtos = _mapper.Map<List<CarFeatureDto>>(cars);
            return new SuccessDataResult<List<CarFeatureDto>>(carDtos, "Cars of the desired brand are listed.");
        }

        [CacheAspect]
        public DataResult<List<CarFeatureDto>> GetAllByFuelType(int fuelId)
        {
            var cars = _carRepository.GetAll(c => c.FuelTypeId == fuelId);
            var carDtos = _mapper.Map<List<CarFeatureDto>>(cars);
            return new SuccessDataResult<List<CarFeatureDto>>(carDtos, "Cars with desired fuel type are listed.");
        }

        [CacheAspect]
        public DataResult<List<CarFeatureDto>> GetAllByGearType(int gearId)
        {
            var cars = _carRepository.GetAll(c => c.GearTypeId == gearId);
            var carDtos = _mapper.Map<List<CarFeatureDto>>(cars);
            return new SuccessDataResult<List<CarFeatureDto>>(carDtos, "Cars with desired gear type are listed.");
        }

        [CacheAspect]
        public DataResult<List<CarFeatureDto>> GetAllByYear(int min, int max)
        {
            var cars = _carRepository.GetAll(c => c.ModelYear >= min && c.ModelYear <= max);
            var carDtos = _mapper.Map<List<CarFeatureDto>>(cars);
            return new SuccessDataResult<List<CarFeatureDto>>(carDtos, "Cars are listed according to the desired year range.");
        }

        [CacheAspect]
        public DataResult<List<CarFeatureDto>> GetByColour(int colour)
        {
            var cars = _carRepository.GetAll(c => c.ColourId == colour);
            var carDtos = _mapper.Map<List<CarFeatureDto>>(cars);
            return new SuccessDataResult<List<CarFeatureDto>>(carDtos, "Cars with desired colour are listed.");
        }

        [CacheAspect]
        public DataResult<CarDto> GetById(int id)
        {
            var car = _carRepository.GetCar(c => c.Id == id);
            return new SuccessDataResult<CarDto>(car, "Car information specified by id is listed.");
        }

        [CacheAspect]
        public DataResult<List<CarFeatureDto>> GetByPrice(int min, int max)
        {
            var cars = _carRepository.GetAll(c => c.Price >= min && c.Price <= max);
            var carDtos = _mapper.Map<List<CarFeatureDto>>(cars);
            return new SuccessDataResult<List<CarFeatureDto>>(carDtos, "Cars are listed according to the desired price range.");
        }

        public Result Update(CarFeatureDto car)
        {
            _carRepository.Update(car);
            return new SuccessResult("Car information updated.");
        }



        private Result CheckCarModelExist(string model)
        {
            var result = _carRepository.Any(c => c.Model == model);
            if (result)
            {
                return new ErrorResult("The car you want to add already exist.");
            }
            return new SuccessResult();
        }

        private Result CheckForbiddenBrand(int brandId)
        {
            if (brandId == 1)
            {
                return new ErrorResult("The sale of this brand is prohibited.");
            }
            return new SuccessResult();
        }

    }
}
