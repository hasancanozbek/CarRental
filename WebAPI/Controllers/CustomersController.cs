using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpPost("Add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.Add(customer);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _customerService.Delete(id);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.Update(customer);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult Get(int id)
        {
            var result = _customerService.GetById(id);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("RentCar")]
        public IActionResult RentCar(int customerId, int carId, string originAddress, string returnAddress)
        {
            var result = _customerService.RentCar(customerId, carId, originAddress, returnAddress);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("ReturnCar")]
        public IActionResult ReturnCar(int carId)
        {
            var result = _customerService.ReturnCar(carId);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllRentDetailsByCustomerId")]
        public IActionResult GetAllRentDetailsByCustomerId(int customerId)
        {
            var result = _customerService.GetAllRentDetailsByCustomerId(customerId);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetRentDetailById")]
        public IActionResult GetRentDetailById(int id)
        {
            var result = _customerService.GetRentDetailById(id);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
