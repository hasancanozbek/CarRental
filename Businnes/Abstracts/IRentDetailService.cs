
using Core.Utilities.Results;
using Entities.Concretes;
using Entities.DTOs;

namespace Business.Abstracts
{
    public interface IRentDetailService
    {
        DataResult<List<RentInformationDto>> GetAllRentDetails();
        DataResult<RentInformationDto> GetRentDetailById(int id);
        DataResult<List<RentDetail>> GetAllRentDetailsByCustomerId(int customerId);
        DataResult<RentDetail> GetRentDetailByCustomerId(int customerId);
    }
}
