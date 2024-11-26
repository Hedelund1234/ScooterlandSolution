using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scooterland.Server.Repositories.EmployeeRepository;
using Scooterland.Shared.Models;
using System.Net;

namespace Scooterland.Server.Controllers
{
	[Route("api/employeeapi")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
        private readonly IEmployeeRepository Repository = new EmployeeRepositoryEF();


        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            if (Repository == null && employeeRepository != null)
            {
                Repository = employeeRepository;
                Console.WriteLine("Repository initialized");
            }
        }


        [HttpGet]
        public IEnumerable<Employee> GetAllEmployees()
        {
            return Repository.GetAllEmployees();
        }

        [HttpDelete("{id:int}")]
        public StatusCodeResult DeleteEmployee(int id)
        {
            Console.WriteLine("Server: Delete employee called: id = " + id);

            bool deleted = Repository.DeleteEmployee(id);
            if (deleted)
            {
                Console.WriteLine("Server: Employee deleted succces");
                int code = (int)HttpStatusCode.OK;
                return new StatusCodeResult(code);
            }
            else
            {
                Console.WriteLine("Server: Employee deleted fail - not found");
                int code = (int)HttpStatusCode.NotFound;
                return new StatusCodeResult(code);
            }
        }

        [HttpPost]
        public void AddEmployee(Employee employee)
        {
            Console.WriteLine("Add employee called: " + employee.ToString());
            Repository.AddEmployee(employee);
        }



        [HttpGet("{id:int}")]
        public Employee FindEmployee(int id)
        {
            var result = Repository.FindEmployee(id);
            return result;
        }

        [HttpPatch]
        public StatusCodeResult UpdateEmployee(Employee employee)
        {
            bool updated = Repository.UpdateEmployee(employee);
            if (updated)
            {
                Console.WriteLine("Server: employee updated succces");
                int code = (int)HttpStatusCode.OK;
                return new StatusCodeResult(code);
            }
            else
            {
                Console.WriteLine("Server: employee updated fail - something went wrong");
                int code = (int)HttpStatusCode.NotFound;
                return new StatusCodeResult(code);
            }
        }
    }
}
