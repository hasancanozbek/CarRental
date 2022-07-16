
using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface ICustomerRepository : IEntityRepository<Customer>
    {
        void Delete(int id);

        //Hatalar giderilecek.
        void RentCar(Customer customer, Car car, string originAddress, string? returnAddress);
        void ReturnCar(Car car);
    }
}
