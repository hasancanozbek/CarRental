
using Core.Entities.Concretes;
using Entities.Concretes;

namespace Core.Adapters.PersonValidation
{
    public class FakeValidation : IPersonValidationService
    {
        public bool IsRealPerson(Customer customer)
        {
            return true;
        }
    }
}
