
using Core.Utilities.Results;
using Entities.Concretes;

namespace Business.Abstracts
{
    public interface IRentDetailService
    {
        DataResult<List<RentDetail>> GetAllRentDetails();
        DataResult<RentDetail> GetRentDetailById(int id);
        DataResult<RentDetail> GetRentDetailByCustomerIdWithNullReturnDate(int customerId);
        DataResult<List<RentDetail>> GetAllRentDetailsByCustomerId(int customerId);
    }
}
