
using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private readonly ICarImageService carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            this.carImageService = carImageService;
        }

        [HttpPost("Add")]
        public IActionResult Add(IFormFile file, int carId)
        {
            //refactor edilecek
            CarImage carImage = new()
            {
                CarId = carId
            };
            var result = carImageService.Add(file, carImage);
            if (result.Status)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        //File ekleme hatası giderilecek.
        [HttpPut("Update")]
        public IActionResult Update(IFormFile file, CarImage carImage)
        {
            var result = carImageService.Update(file, carImage);
            if (result.Status)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var result = carImageService.Delete(id);
            if (result.Status)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = carImageService.GetAll();
            if (result.Status)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetAllByCarId")]
        public IActionResult GetAllByCarId(int carId)
        {
            var result = carImageService.GetAllByCarId(carId);
            if (result.Status)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = carImageService.GetById(id);
            if (result.Status)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
