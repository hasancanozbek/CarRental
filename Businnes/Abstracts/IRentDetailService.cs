
using Core.Utilities.Results;
using Entities.Concretes;
using System.Linq.Expressions;

namespace Business.Abstracts
{
    public interface IRentDetailService
    {
        DataResult<List<RentDetail>> GetAllRentDetails(Expression<Func<RentDetail, bool>> filter = null);
        DataResult<RentDetail> GetRentDetail(Expression<Func<RentDetail, bool>> filter);
    }
}
