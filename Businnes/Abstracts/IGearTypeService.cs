using Core.Utilities.Results;
using Entities.Concretes;

namespace Business.Abstracts
{
    public interface IGearTypeService
    {
        DataResult<GearType> Add(GearType gearType);
        DataResult<GearType> Update(GearType gearType);
        Result Delete(GearType gearType);
        DataResult<List<GearType>> GetAll();
        DataResult<GearType> GetById(int id);
    }
}
