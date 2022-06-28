using AppTest.Models;


namespace AppTest.Contracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetEmployee(Guid id);

        void CreateEmployee(Employee employee);
    }
}
