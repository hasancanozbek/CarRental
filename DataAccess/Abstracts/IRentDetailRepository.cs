
using System.Linq.Expressions;
using Core.DataAccess;
using Entities.Concretes;
using Entities.DTOs;

namespace DataAccess.Abstracts
{
    public interface IRentDetailRepository : IEntityRepository<RentDetail>
    {
        List<RentInformationDto> GetAllRentDetails(Expression<Func<RentInformationDto, bool>> filter = null);
        RentInformationDto GetRentDetail(Expression<Func<RentInformationDto, bool>> filter);
    }
}
