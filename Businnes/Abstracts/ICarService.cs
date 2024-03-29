﻿
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstracts
{
    public interface ICarService
    {
        Result Add(CarFeatureDto car);
        Result Delete(int id);
        Result Update(CarFeatureDto car);
        DataResult<CarDto> GetById(int id);
        DataResult<List<CarDto>> GetAll();
        DataResult<List<CarFeatureDto>> GetByPrice(int min, int max);
        DataResult<List<CarFeatureDto>> GetAllByGearType(int gearId);
        DataResult<List<CarFeatureDto>> GetAllByFuelType(int fuelId);
        DataResult<List<CarFeatureDto>> GetByColour(int colour);
        DataResult<List<CarFeatureDto>> GetAllByYear(int min, int max);
        DataResult<List<CarFeatureDto>> GetAllByBrand(int brandId);
    }
}
