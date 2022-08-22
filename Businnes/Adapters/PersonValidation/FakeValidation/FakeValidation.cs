
using Core.Adapters.PersonValidation;
using Entities.Concretes;

namespace Business.Adapters.PersonValidation.FakeValidation
{
    public class FakeValidation : IPersonValidationService
    {
        public bool IsRealPerson(Customer customer)
        {
            return true;
        }
    }
}
