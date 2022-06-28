using Testing.Contracts;
using Testing.Models;


namespace Testing.Repository
{
    public class EmployeeRepositroy:IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepositroy(EmployeeContext context)
        {
            _context = context;
        }
        public IEnumerable<Employee> GetAll() => _context.Employee.ToList();

        public Employee GetEmployee(Guid id) => _context.Employee.SingleOrDefult(e => e.Id.Equals(id));


        public  void CreateEmployee(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
        }
        public Employee GetEmployee(int id)
        {
            throw new NotImplementedException();
        }

    }
}
