﻿
using Core.Utilities.Results;
using Entities.Concretes;
using Entities.DTOs;

namespace Business.Abstracts
{
    public interface ICustomerService
    {
        Result Add(Customer customer);
        Result Update(Customer customer);
        Result Delete(int id);
        DataResult<CustomerDto> GetById(int id);
        DataResult<List<CustomerDto>> GetAll();
        Result RentCar(int customerId, int carId, int originOffice, int returnOffice);
        Result ReturnCar(int carId, int customerId);
        DataResult<List<RentDetail>> GetAllRentDetailsByCustomerId(int customerId);
        DataResult<RentInformationDto> GetRentDetailById(int id);
    }
}
