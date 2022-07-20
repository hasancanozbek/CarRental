
using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class FuelTypeManager : IFuelTypeService
    {

        private readonly IFuelTypeRepository fuelTypeRepository;

        public FuelTypeManager(IFuelTypeRepository fuelTypeRepository)
        {
            this.fuelTypeRepository = fuelTypeRepository;
        }

        public DataResult<FuelType> Add(FuelType fuelType)
        {
            fuelTypeRepository.Add(fuelType);
            return new SuccessDataResult<FuelType>(fuelType, "Fuel type added to database.");
        }

        public Result Delete(FuelType fuelType)
        {
            fuelTypeRepository.Delete(fuelType);
            return new SuccessResult("Fuel type removed from database.");
        }

        public DataResult<List<FuelType>> GetAll()
        {
            var fuels = fuelTypeRepository.GetAll();
            return new SuccessDataResult<List<FuelType>>(fuels,"All fuel types listed.");
        }

        public DataResult<FuelType> GetById(int id)
        {
            var fuel = fuelTypeRepository.Get(f => f.Id == id);
            return new SuccessDataResult<FuelType>(fuel, "The desired fuel type is listed according to the id.");
        }

        public DataResult<FuelType> Update(FuelType fuelType)
        {
            fuelTypeRepository.Update(fuelType);
            return new SuccessDataResult<FuelType>(fuelType,"Fuel type information updated.");
        }
    }
}
