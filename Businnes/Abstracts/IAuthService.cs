
using Core.Entities.Concretes;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Concretes;
using Entities.DTOs;

namespace Business.Abstracts
{
    public interface IAuthService
    {
        DataResult<Customer> RegisterForCustomer(CustomerForRegisterDto userForRegisterDto);
        DataResult<Employee> RegisterForEmployee(EmployeeForRegisterDto userForRegisterDto);
        DataResult<User> Login(UserForLoginDto userForLoginDto);
        Result UserExists(string email);
        DataResult<AccessToken> CreateAccessToken(User user);
    }
}
