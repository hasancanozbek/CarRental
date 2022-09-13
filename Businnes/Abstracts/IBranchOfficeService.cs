
using Core.Utilities.Results;
using Entities.Concretes;

namespace Business.Abstracts
{
    public interface IBranchOfficeService
    {
        Result Add(BranchOffice office);
        Result Update(BranchOffice office);
        Result Delete(BranchOffice office);
        DataResult<List<BranchOffice>> GetAllOffices();
        DataResult<BranchOffice> GetOffice(int id);
    }
}
