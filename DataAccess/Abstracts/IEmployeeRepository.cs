
using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IEmployeeRepository : IEntityRepository<Employee>
    {
        void Delete(int id);
    }
}
