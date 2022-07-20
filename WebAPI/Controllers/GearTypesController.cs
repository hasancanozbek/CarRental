using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GearTypesController : ControllerBase
    {
        private readonly IGearTypeService gearTypeService;

        public GearTypesController(IGearTypeService gearTypeService)
        {
            this.gearTypeService = gearTypeService;
        }

        [HttpPost("Add")]
        public IActionResult Add(GearType gearType)
        {
            var result = gearTypeService.Add(gearType);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpDelete("Delete")]
        public IActionResult Delete(GearType gearType)
        {
            var result = gearTypeService.Delete(gearType);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(GearType gearType)
        {
            var result = gearTypeService.Update(gearType);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult Get(int id)
        {
            var result = gearTypeService.GetById(id);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = gearTypeService.GetAll();
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
