
using Business.Abstracts;
using Core.CustomExceptions;
using Core.Entities.Concretes;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities;
using Entities.Concretes;
using Entities.DTOs;

namespace Business.Concretes
{
    public class AuthManager : IAuthService
    {
        private IUserService userService;
        private ICustomerService customerService;
        private IEmployeeService employeeService;
        private ITokenHelper tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, ICustomerService customerService, IEmployeeService employeeService)
        {
            this.userService = userService;
            this.tokenHelper = tokenHelper;
            this.customerService = customerService;
            this.employeeService = employeeService;
        }

        public DataResult<Customer> RegisterForCustomer(CustomerForRegisterDto customerForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(customerForRegisterDto.Password, out passwordHash, out passwordSalt);
            Customer customer = new Customer
            {
                Email = customerForRegisterDto.Email,
                FirstName = customerForRegisterDto.FirstName,
                LastName = customerForRegisterDto.LastName,
                Telephone = customerForRegisterDto.Telephone,
                NationalId = customerForRegisterDto.NationalId,
                YearOfBirth = customerForRegisterDto.YearOfBirth,
                Address = customerForRegisterDto.Address,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            var result = customerService.Add(customer);
            if (result.Status)
            {
                return new SuccessDataResult<Customer>(customer, "Customer registered successfully.");
            }
            return new ErrorDataResult<Customer>(result.Message);
        }

        public DataResult<Employee> RegisterForEmployee(EmployeeForRegisterDto employeeeForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(employeeeForRegisterDto.Password, out passwordHash, out passwordSalt);
            Employee employee = new Employee
            {
                Email = employeeeForRegisterDto.Email,
                FirstName = employeeeForRegisterDto.FirstName,
                LastName = employeeeForRegisterDto.LastName,
                Telephone = employeeeForRegisterDto.Telephone,
                Department = employeeeForRegisterDto.Department,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            employeeService.Add(employee);
            return new SuccessDataResult<Employee>(employee, "Employee registered successfully.");
        }

        public DataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                //return new ErrorDataResult<User>("User not found.");
                throw new UnauthorizedException("User not found.");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                //return new ErrorDataResult<User>("Email or password incorrect.");
                throw new UnauthorizedException("Email or password incorrect.");
            }

            return new SuccessDataResult<User>(userToCheck, "Login was successfully.");
        }

        public Result UserExists(string email)
        {
            if (userService.GetByMail(email) != null)
            {
                //return new ErrorResult("User already exist.");
                throw new UnauthorizedException("User already exist.");
            }
            return new SuccessResult();
        }

        public DataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = userService.GetClaims(user);
            var accessToken = tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Access token created.");
        }

    }
}
