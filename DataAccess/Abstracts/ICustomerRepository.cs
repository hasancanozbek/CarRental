
using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface ICustomerRepository : IEntityRepository<Customer>
    {
        void Delete(int id);
        void RentCar(int customerId, int carId, string originAddress, string returnAddress);
        void ReturnCar(int carId);
    }
}
