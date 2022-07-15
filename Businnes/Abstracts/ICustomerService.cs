
using Core.Utilities.Results;
using Entities.DTOs;

namespace Businnes.Abstracts
{
    public interface ICustomerService
    {
        Result Add(CustomerDto customer);
        Result Update(CustomerDto customer);
        Result Delete(int id);
        DataResult<CustomerDto> GetById(int id);
        DataResult<List<CustomerDto>> GetAll();
    }
}
