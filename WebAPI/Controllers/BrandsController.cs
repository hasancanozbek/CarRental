using Businnes.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService brandService;

        public BrandsController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Brand brand)
        {
            var result = brandService.Add(brand);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpDelete("Delete")]
        public IActionResult Delete(Brand brand)
        {
            var result = brandService.Delete(brand);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(Brand brand)
        {
            var result = brandService.Update(brand);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult Get(int id)
        {
            var result = brandService.GetById(id);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = brandService.GetAll();
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
