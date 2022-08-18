
using AutoMapper;
using Business.Abstracts;
using Business.ValidationRules.FluentValidation;
using Core.Adapters.PersonValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;

namespace Business.Concretes
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IRentDetailService _rentDetailService;
        private readonly IMapper _mapper;
        private readonly IPersonValidationService personValidationService;
        public CustomerManager(ICustomerRepository customerRepository, IMapper mapper, IRentDetailService rentDetailService, IPersonValidationService personValidationService)
        { 
            _customerRepository = customerRepository;
            _mapper = mapper;
            _rentDetailService = rentDetailService;
            this.personValidationService = personValidationService;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public Result Add(Customer customer)
        {
            var result = BusinessRules.Run(CheckCustomerRealPerson(customer),CheckCustomerEmailExist(customer.Email));
            if (result != null)
            {
                return result;
            }
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

        public DataResult<List<RentDetail>> GetAllRentDetailsByCustomerId(int customerId)
        {
            var rentDetails = _rentDetailService.GetAllRentDetails(r => r.CustomerId == customerId);
            return new SuccessDataResult<List<RentDetail>>(rentDetails.Data, "Rent details specified by customer id is listed.");
        }

        public DataResult<CustomerDto> GetById(int id)
        {
            var customer = _customerRepository.Get(c => c.Id == id);
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return new SuccessDataResult<CustomerDto>(customerDto, "Customer information specified by id is listed.");
        }

        public DataResult<RentDetail> GetRentDetailById(int id)
        {
            var rentDetail = _rentDetailService.GetRentDetail(r => r.Id == id);
            return new SuccessDataResult<RentDetail>(rentDetail.Data, "Rent detail specified by id is listed.");
        }

        public Result RentCar(int customerId, int carId, string originAddress, string returnAddress)
        {
            var result = BusinessRules.Run(CheckCustomerHaveActiveRental(customerId));
            if(result != null)
            {
                return result;
            }
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

        

        private Result CheckCustomerEmailExist(string email)
        {
            var result = _customerRepository.Any(c => c.Email == email);
            if (result)
            {
                return new ErrorResult("Email registered before. Please enter a new email address.");
            }
            return new SuccessResult();
        }

        private Result CheckCustomerHaveActiveRental(int customerId)
        {
            var result = _rentDetailService.GetAllRentDetails(r => r.CustomerId == customerId && r.ReturnDate == null);
            if(result.Data != null)
            {
                return new ErrorResult("The car was previously rented but not delivered. Please return the existing car before renting a new one.");
            }
            return new SuccessResult();
        }

        private Result CheckCustomerRealPerson(Customer customer)
        {
            var isReal = personValidationService.IsRealPerson(customer);
            if (isReal)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Person failed to pass mernis verification.");
        }
    }
}
