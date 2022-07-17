
using AutoMapper;
using Businnes.Abstracts;
using Businnes.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;

namespace Businnes.Concretes
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerManager(ICustomerRepository customerRepository, IMapper mapper)
        {
            this._customerRepository = customerRepository;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public Result Add(Customer customer)
        {
            _customerRepository.Add(customer);
            return new SuccessResult("Customer added to database successfully.");
        }

        public Result Delete(int id)
        {
            _customerRepository.Delete(id);
            return new SuccessResult("Customer removed from database successfully.");
        }

        public DataResult<List<CustomerDto>> GetAll()
        {
            var customers = _customerRepository.GetAll();
            var customerDtos = _mapper.Map<List<CustomerDto>>(customers);
            return new SuccessDataResult<List<CustomerDto>>(customerDtos,"All customers listed.");
        }

        public DataResult<CustomerDto> GetById(int id)
        {
            var customer = _customerRepository.Get(c => c.Id == id);
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return new SuccessDataResult<CustomerDto>(customerDto, "Customer information specified by id is listed.");
        }

        public Result RentCar(int customerId, int carId, string originAddress, string returnAddress)
        {
            _customerRepository.RentCar(customerId, carId, originAddress, returnAddress);
            return new SuccessResult("Car rented successfully.");
        }

        public Result ReturnCar(int carId)
        {
            _customerRepository.ReturnCar(carId);
            return new SuccessResult("Car returned successfully");
        }

        public Result Update(Customer customer)
        {
            _customerRepository.Update(customer);
            return new SuccessResult("Customer informations updated.");
        }
    }
}
