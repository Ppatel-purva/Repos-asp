using Testing.Models;

namespace Testing.Contracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetEmployee(Guid id);

        void CreateEmployee(Employee employee);
    }
}
