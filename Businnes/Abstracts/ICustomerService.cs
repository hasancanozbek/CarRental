﻿
using Core.Utilities.Results;
using Entities.Concretes;
using Entities.DTOs;

namespace Businnes.Abstracts
{
    public interface ICustomerService
    {
        Result Add(Customer customer);
        Result Update(Customer customer);
        Result Delete(int id);
        DataResult<CustomerDto> GetById(int id);
        DataResult<List<CustomerDto>> GetAll();
        //Hatalar giderilecek.
        Result RentCar(Customer customer, Car car, string originAddress, string? returnAddress);
        Result ReturnCar(Car car);
    }
}