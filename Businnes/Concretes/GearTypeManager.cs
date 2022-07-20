using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class GearTypeManager : IGearTypeService
    {
        private readonly IGearTypeRepository gearTypeRepository;

        public GearTypeManager(IGearTypeRepository gearTypeRepository)
        {
            this.gearTypeRepository = gearTypeRepository;
        }

        public DataResult<GearType> Add(GearType gearType)
        {
            gearTypeRepository.Add(gearType);
            return new SuccessDataResult<GearType>(gearType,"Gear type added to database.");
        }

        public Result Delete(GearType gearType)
        {
            gearTypeRepository.Delete(gearType);
            return new SuccessResult("Gear type removed from database.");
        }

        public DataResult<List<GearType>> GetAll()
        {
            var gearTypes = gearTypeRepository.GetAll();
            return new SuccessDataResult<List<GearType>>(gearTypes,"All gear types listed.");
        }

        public DataResult<GearType> GetById(int id)
        {
            var gearType = gearTypeRepository.Get(g => g.Id == id);
            return new SuccessDataResult<GearType>(gearType, "The desired gear type is listed according to the id.");
        }

        public DataResult<GearType> Update(GearType gearType)
        {
            gearTypeRepository.Update(gearType);
            return new SuccessDataResult<GearType>(gearType,"Gear type information updated.");
        }
    }
}
