using Scooterland.Server.DataAccess;
using Scooterland.Shared.Models;

namespace Scooterland.Server.Repositories.EmployeeRepository
{
	public class EmployeeRepositoryEF : IEmployeeRepository
	{
		public bool AddEmployee(Employee employee)
		{
			var db = new ScooterlandDbContext();
			int counterBefore = db.Employees.Count();
			db.Employees.Add(employee);
			db.SaveChanges();
			int counterAfter = db.Employees.Count();

			if (counterBefore < counterAfter)
			{
				return true;
			}
			return false;

		}

		public bool DeleteEmployee(int id)
		{
			int counterBefore = 0;
			int counterAfter = 0;
			var db = new ScooterlandDbContext();
			Employee employee;
			employee = db.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
			if (id == employee.EmployeeId)
			{
				counterBefore = db.Employees.Count();
				db.Employees.Remove(employee);
				db.SaveChanges();
				counterAfter = db.Employees.Count();
			}
			if (counterBefore < counterAfter)
			{
				return true;
			}
			return false;
		}


		public bool UpdateEmployee(Employee employee)
		{
			var db = new ScooterlandDbContext();
			Employee foundEmployee = db.Employees.Where(x => x.EmployeeId == employee.EmployeeId).FirstOrDefault();

			var originalEmployee = foundEmployee;

			foundEmployee.Name = employee.Name;
			foundEmployee.Role = employee.Role;			
			db.SaveChanges();

			if (originalEmployee.Name != foundEmployee.Name ||
				originalEmployee.Role != foundEmployee.Role)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		//return item with id = -1 if not found
		public Employee FindEmployee(int id)
		{
			var db = new ScooterlandDbContext();
			Employee employee;
			try
			{
				employee = db.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
			}
			catch
			{
				employee = new Employee(-1);
			}

			return employee;
		}

		public List<Employee> GetAllEmployees()
		{
			var db = new ScooterlandDbContext();
			List<Employee> employees;
			try
			{
				employees = db.Employees.ToList();
			}
			catch
			{
				employees = new List<Employee>();
			}
			return employees;
		}
	}
}
