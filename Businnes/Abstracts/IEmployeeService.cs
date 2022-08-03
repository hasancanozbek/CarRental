
using Core.Utilities.Results;
using Entities.Concretes;

namespace Business.Abstracts
{
    public interface IEmployeeService
    {
        Result Add(Employee employee);
        Result Update(Employee employee);
        Result Delete(int id);
        DataResult<Employee> GetById(int id);
        DataResult<List<Employee>> GetAll();
    }
}
