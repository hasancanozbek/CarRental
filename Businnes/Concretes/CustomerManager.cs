
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
        public Result Add(CustomerDto customer)
        {
            var customerToAdded = _mapper.Map<Customer>(customer);
            _customerRepository.Add(customerToAdded);
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

        public Result Update(CustomerDto customer)
        {
            _customerRepository.Update(customer);
            return new SuccessResult("Customer informations updated.");
        }
    }
}
