using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly SqlConnection _con;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable = new DataTable();
        // GET: api/<EmployeeController>
        public EmployeeController()
        {
            _con = new SqlConnection("Server=EFCYIT-LTR903;Database=EmployeeData;Trusted_Connection=True;MultipleActiveResultSets=true");
            _con.Open();
        }

        public List<Employee> Get()
        {
            List<Employee> customers = new List<Employee>();
            dataAdapter = new SqlDataAdapter("SELECT * FROM Employee", _con);
            dataAdapter.Fill(dataTable);
            _con.Close();
            foreach (DataRow row in dataTable.Rows)
            {
                customers.Add(new Employee
                {
                    EmpID = Convert.ToInt32(row["EmpID"]),
                    LastName = Convert.ToString(row["LastName"]),
                    FirstName = Convert.ToString(row["FirstName"]),
                    Address = Convert.ToString(row["Address"]),
                    City = Convert.ToString(row["City"])
                });
            }
            return customers;
        }



        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return Get().Find(e=>e.EmpID==id);
        }

        // POST api/<EmployeeController>
        [HttpPost]

        public ActionResult<Employee> Create([FromBody] Employee employee)
        {
                
                dataAdapter = new SqlDataAdapter($"INSERT INTO Employee(FirstName,LastName,Address,City) VALUES('{employee.FirstName}','{employee.LastName}','{employee.Address}','{employee.City}')", _con);
                dataAdapter.Fill(dataTable);
                _con.Close();
                
                return employee;
        }

            // PUT api/<EmployeeController>/5
            [HttpPut("{id}")]
        public ActionResult<Employee> Edit(int id, [FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                dataAdapter = new SqlDataAdapter($"UPDATE Employee " +
                    $"SET FirstName= '{employee.FirstName}', " +
                    $"LastName='{employee.LastName}', " +
                    $"Address='{employee.Address}', " +
                    $"City='{employee.City}' " +
                    $"WHERE EmpID = {id}", _con);
                dataAdapter.Fill(dataTable);
            }
            return employee;
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dataAdapter = new SqlDataAdapter($"DELETE from Employee " +
                    $"WHERE EmpID = {id}", _con);
            dataAdapter.Fill(dataTable);
        }
    }
}
