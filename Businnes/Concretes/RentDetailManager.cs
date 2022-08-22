using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System.Linq.Expressions;

namespace Business
{
    public class RentDetailManager : IRentDetailService
    {
        private readonly IRentDetailRepository rentDetailRepository;
        public RentDetailManager(IRentDetailRepository rentDetailRepository)
        {
            this.rentDetailRepository = rentDetailRepository;
        }

        public DataResult<List<RentDetail>> GetAllRentDetails()
        {
            var rentDetails = rentDetailRepository.GetAll();
            return new SuccessDataResult<List<RentDetail>>(rentDetails);
        }

        public DataResult<RentDetail> GetRentDetailById(int id)
        {
            var rentDetail = rentDetailRepository.Get(r => r.Id == id);
            return new SuccessDataResult<RentDetail>(rentDetail);
        }

        public DataResult<RentDetail> GetRentDetailByCustomerIdWithNullReturnDate(int customerId)
        {
            var rentDetail = rentDetailRepository.Get(r => r.CustomerId == customerId && r.ReturnDate == null);
            return new SuccessDataResult<RentDetail>(rentDetail);
        }

        public DataResult<List<RentDetail>> GetAllRentDetailsByCustomerId(int customerId)
        {
            var rentDetails = rentDetailRepository.GetAll(r => r.CustomerId == customerId);
            return new SuccessDataResult<List<RentDetail>>(rentDetails);
        }
    }
}