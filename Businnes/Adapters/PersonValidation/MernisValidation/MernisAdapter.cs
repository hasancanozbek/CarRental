
using Core.Adapters.PersonValidation;
using Entities.Concretes;
using Mernis;

namespace Business.Adapters.PersonValidation.MernisValidation
{
    public class MernisAdapter : IPersonValidationService
    {
        public bool IsRealPerson(Customer customer)
        {
            var mernisClient = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var tcKimlikDogrulamaServisResponse = mernisClient.TCKimlikNoDogrulaAsync(long.Parse(customer.NationalId), customer.FirstName.ToUpper(), customer.LastName.ToUpper(), customer.YearOfBirth).GetAwaiter().GetResult();
            return tcKimlikDogrulamaServisResponse.Body.TCKimlikNoDogrulaResult;
        }
    }
}
