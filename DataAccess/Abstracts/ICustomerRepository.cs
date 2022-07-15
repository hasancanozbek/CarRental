
using Core.DataAccess;
using Entities.Concretes;
using Entities.DTOs;

namespace DataAccess.Abstracts
{
    public interface ICustomerRepository : IEntityRepository<Customer>
    {
        void Delete(int id);
        void Update(CustomerDto customer);
    }
}
