using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentDetailsController : ControllerBase
    {

        private readonly IRentDetailService rentDetailService;

        public RentDetailsController(IRentDetailService rentDetailService)
        {
            this.rentDetailService = rentDetailService;
        }

        [HttpGet("GetAllRentDetails")]
        public IActionResult GetAllRentDetails()
        {
            var result = rentDetailService.GetAllRentDetails();
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
