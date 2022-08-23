
using Core.DataAccess;
using Entities.Concretes;
using Entities.DTOs;

namespace DataAccess.Abstracts
{
    public interface ICustomerRepository : IEntityRepository<Customer>
    {
        void Delete(int id);
        RentInformationDto RentCar(int customerId, int carId, string originAddress, string returnAddress);
        void ReturnCar(int carId);
    }
}
