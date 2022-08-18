
using Business.Abstracts;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Status)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Status)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("RegisterForCustomer")]
        public ActionResult RegisterForCustomer(CustomerForRegisterDto customerForRegisterDto)
        {
            var userExists = _authService.UserExists(customerForRegisterDto.Email);
            if (!userExists.Status)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.RegisterForCustomer(customerForRegisterDto);

            if (registerResult.Status)
            {
                var tokenResult = _authService.CreateAccessToken(registerResult.Data);
                if (tokenResult.Status)
                {
                    return Ok(tokenResult.Data);
                }
                return BadRequest(tokenResult.Message);
            }
            return BadRequest(registerResult.Message);
        }

        [HttpPost("RegisterForEmployee")]
        public ActionResult RegisterForEmployee(EmployeeForRegisterDto employeeForRegisterDto)
        {
            var userExists = _authService.UserExists(employeeForRegisterDto.Email);
            if (!userExists.Status)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.RegisterForEmployee(employeeForRegisterDto);
            var tokenResult = _authService.CreateAccessToken(registerResult.Data);
            if (tokenResult.Status)
            {
                return Ok(tokenResult.Data);
            }

            return BadRequest(tokenResult.Message);
        }
    }
}
