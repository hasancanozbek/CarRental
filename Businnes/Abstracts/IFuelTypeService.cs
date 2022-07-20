
using Core.Utilities.Results;
using Entities.Concretes;

namespace Business.Abstracts
{
    public interface IFuelTypeService
    {
        DataResult<FuelType> Add(FuelType fuelType);
        DataResult<FuelType> Update(FuelType fuelType);
        Result Delete(FuelType fuelType);
        DataResult<List<FuelType>> GetAll();
        DataResult<FuelType> GetById(int id);
    }
}
