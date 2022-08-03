
using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    internal class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public Result Add(Employee employee)
        {
            employeeRepository.Add(employee);
            return new SuccessResult("Employee added to database successfully.");
        }

        public Result Delete(int id)
        {
            employeeRepository.Delete(id);
            return new SuccessResult("Employee deleted from database successfully.");
        }

        public DataResult<List<Employee>> GetAll()
        {
            var employees = employeeRepository.GetAll();
            return new SuccessDataResult<List<Employee>>(employees,"All employees working in the company are listed.");
        }

        public DataResult<Employee> GetById(int id)
        {
            var employee = employeeRepository.Get(e => e.Id == id);
            return new SuccessDataResult<Employee>(employee,"Employee informations are listed according to given id.");
        }

        public Result Update(Employee employee)
        {
            employeeRepository.Update(employee);
            return new SuccessResult("Employee informations updated successfully.");
        }
    }
}
