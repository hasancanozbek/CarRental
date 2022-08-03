
using Core.Entities.Concretes;
using Core.Utilities.Results;

namespace Business.Abstracts
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
    }
}
