
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Adapters.PersonValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.MessageBrokers;
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
        private readonly IMessageBrokerService messageBrokerPublisherService;
        public CustomerManager(ICustomerRepository customerRepository, IMapper mapper, IRentDetailService rentDetailService, IPersonValidationService personValidationService, IMessageBrokerService messageBrokerPublisherService)
        { 
            _customerRepository = customerRepository;
            _mapper = mapper;
            _rentDetailService = rentDetailService;
            this.personValidationService = personValidationService;
            this.messageBrokerPublisherService = messageBrokerPublisherService;
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
            var rentDetails = _rentDetailService.GetAllRentDetailsByCustomerId(customerId);
            return new SuccessDataResult<List<RentDetail>>(rentDetails.Data, "Rent details specified by customer id is listed.");
        }

        public DataResult<CustomerDto> GetById(int id)
        {
            var customer = _customerRepository.Get(c => c.Id == id);
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return new SuccessDataResult<CustomerDto>(customerDto, "Customer information specified by id is listed.");
        }

        public DataResult<RentInformationDto> GetRentDetailById(int id)
        {
            var rentDetail = _rentDetailService.GetRentDetailById(id);
            return new SuccessDataResult<RentInformationDto>(rentDetail.Data, "Rent detail specified by id is listed.");
        }

        [SecuredOperation("customer,admin,customer support")]
        [CacheRemoveAspect("ICarService.Get")]
        public Result RentCar(int customerId, int carId, int originOffice, int returnOffice)
        {
            var result = BusinessRules.Run(CheckCustomerHaveActiveRental(customerId));
            if(result != null)
            {
                return result;
            }
            var rentDetail = _customerRepository.RentCar(customerId, carId, originOffice, returnOffice);

            messageBrokerPublisherService.PublishMessage(rentDetail);
            return new SuccessResult("Car rented successfully.");
        }

        [SecuredOperation("customer,admin,customer support")]
        [CacheRemoveAspect("ICarService.Get")]
        public Result ReturnCar(int carId, int customerId)
        {
            var result = BusinessRules.Run(CheckIfCarRentedToCustomer(customerId, carId));
            if (result != null)
            {
                return result;
            }
            _customerRepository.ReturnCar(carId);
            return new SuccessResult("Car returned successfully.");
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
            var resultRents = _rentDetailService.GetAllRentDetailsByCustomerId(customerId);
            var activeRentDetail = resultRents.Data.Find(r => r.ReturnDate == null);
            if(activeRentDetail != null)
            {
                return new ErrorResult("A car was previously rented but not delivered. Please return the existing car before renting a new one.");
            }
            return new SuccessResult();
        }

        private Result CheckIfCarRentedToCustomer(int customerId, int carId)
        {
            var resultRent = _rentDetailService.GetRentDetailByCustomerId(customerId);
            var result = resultRent.Data.CarId == carId;
            if (result)
            {
                return new SuccessResult();
            }
            return  new ErrorResult("No records were found that match the given customer and car.");
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
