using Business.Abstracts;
using Core.Utilities.MessageBrokers.RabbitMQ;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;

namespace Business
{
    public class RentDetailManager : IRentDetailService
    {
        private readonly IRentDetailRepository rentDetailRepository;
        public RentDetailManager(IRentDetailRepository rentDetailRepository)
        {
            this.rentDetailRepository = rentDetailRepository;
        }

        public DataResult<List<RentInformationDto>> GetAllRentDetails()
        {
            var rentDetails = rentDetailRepository.GetAllRentDetails();
            return new SuccessDataResult<List<RentInformationDto>>(rentDetails);
        }

        public DataResult<RentInformationDto> GetRentDetailById(int id)
        {
            var rentDetail = rentDetailRepository.GetRentDetail(r => r.Id == id);
            return new SuccessDataResult<RentInformationDto>(rentDetail);
        }

        public DataResult<List<RentDetail>> GetAllRentDetailsByCustomerId(int customerId)
        {
            var rentDetails = rentDetailRepository.GetAll(r => r.CustomerId == customerId);
            return new SuccessDataResult<List<RentDetail>>(rentDetails);
        }

        public DataResult<RentDetail> GetRentDetailByCustomerId(int customerId)
        {
            var rentDetail = rentDetailRepository.Get(r => r.CustomerId == customerId && r.ReturnDate==null);
            return new SuccessDataResult<RentDetail>(rentDetail);
        }
    }
}