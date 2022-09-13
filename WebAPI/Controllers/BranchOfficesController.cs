using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchOfficesController : Controller
    {
        private readonly IBranchOfficeService branchOfficeService;

        public BranchOfficesController(IBranchOfficeService branchOfficeService)
        {
            this.branchOfficeService = branchOfficeService;
        }

        [HttpPost("Add")]
        public IActionResult Add(BranchOffice office)
        {
            var result = branchOfficeService.Add(office);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpDelete("Delete")]
        public IActionResult Delete(BranchOffice office)
        {
            var result = branchOfficeService.Delete(office);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(BranchOffice office)
        {
            var result = branchOfficeService.Update(office);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult Get(int id)
        {
            var result = branchOfficeService.GetOffice(id);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = branchOfficeService.GetAllOffices();
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
