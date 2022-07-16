﻿using Businnes.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
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
        public IActionResult Add(Customer car)
        {
            var result = _customerService.Add(car);
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

        //Parametre hatası düzeltilecek
        //[HttpPut("RentCar")]
        //public IActionResult RentCar(Customer customer, Car car, string originAddress, string returnAddress)
        //{
        //    var result = _customerService.RentCar(customer, car, originAddress, returnAddress);
        //    if (result.Status)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
    }
}
