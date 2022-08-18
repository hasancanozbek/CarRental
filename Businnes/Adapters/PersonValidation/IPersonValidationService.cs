
using Core.Entities.Concretes;
using Entities.Concretes;

namespace Core.Adapters.PersonValidation
{
    public interface IPersonValidationService
    {
        bool IsRealPerson(Customer customer);
    }
}
