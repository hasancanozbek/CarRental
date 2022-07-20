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

        public DataResult<List<RentDetail>> GetAllRentDetails(Expression<Func<RentDetail, bool>> filter = null)
        {
            var rentDetails = rentDetailRepository.GetAll(filter);
            return new SuccessDataResult<List<RentDetail>>(rentDetails);
        }

        public DataResult<RentDetail> GetRentDetail(Expression<Func<RentDetail, bool>> filter)
        {
            var rentDetail = rentDetailRepository.Get(filter);
            return new SuccessDataResult<RentDetail>(rentDetail);
        }
    }
}