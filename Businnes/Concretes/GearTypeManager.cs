using Businnes.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Businnes.Concretes
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
            throw new NotImplementedException();
        }

        public Result Delete(GearType gearType)
        {
            throw new NotImplementedException();
        }

        public DataResult<List<GearType>> GetAll()
        {
            throw new NotImplementedException();
        }

        public DataResult<GearType> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public DataResult<GearType> Update(GearType gearType)
        {
            throw new NotImplementedException();
        }
    }
}
