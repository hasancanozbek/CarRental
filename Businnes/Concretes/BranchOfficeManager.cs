
using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class BranchOfficeManager : IBranchOfficeService
    {
        private readonly IBranchOfficeRepository branchOfficeRepository;

        public BranchOfficeManager(IBranchOfficeRepository branchOfficeRepository)
        {
            this.branchOfficeRepository = branchOfficeRepository;
        }

        public Result Add(BranchOffice office)
        {
            branchOfficeRepository.Add(office);
            return new SuccessResult("New office added successfully.");
        }

        public Result Update(BranchOffice office)
        {
            branchOfficeRepository.Update(office);
            return new SuccessResult("Current office information updated.");
        }

        public Result Delete(BranchOffice office)
        {
            branchOfficeRepository.Delete(office);
            return new SuccessResult("Current office removed from database.");
        }

        public DataResult<List<BranchOffice>> GetAllOffices()
        {
            var offices = branchOfficeRepository.GetAll();
            return new SuccessDataResult<List<BranchOffice>>(offices,"All offices listed successfully.");
        }

        public DataResult<BranchOffice> GetOffice(int id)
        {
            var office = branchOfficeRepository.Get(office => office.Id == id);
            return new SuccessDataResult<BranchOffice>(office, "Requested office information listed.");
        }
    }
}
