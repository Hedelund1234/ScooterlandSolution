using Microsoft.EntityFrameworkCore;
using Scooterland.Server.DataAccess;
using Scooterland.Shared.Models;

namespace Scooterland.Server.Repositories.EmployeeRepository
{
	public class EmployeeRepositoryEF : IEmployeeRepository
	{
		public void AddEmployee(Employee employee)
		{
			var db = new ScooterlandDbContext();
			db.Employees.Add(employee);
			db.SaveChanges();
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
			Employee foundEmployee = db.Employees.Where(x => x.EmployeeId == employee.EmployeeId).Include(s => s.Specializations).FirstOrDefault();
			

			var originalEmployee = foundEmployee;
			//Remvoes specialization from EmployeeSpecialization table
			if (employee.Specializations.Count() < foundEmployee.Specializations.Count())
			{
				var specializationsToRemove = foundEmployee.Specializations
							.Where(f => !employee.Specializations // Filter foundEmployee.Specializations to find those not in employee.Specializations
							.Any(employee => employee.SpecializationId == f.SpecializationId)).Last(); // Check if any Specialization in employee.Specializations has the same ID as foundEmployee.Specializations

				foundEmployee.Specializations.Remove(specializationsToRemove);
				db.SaveChanges();
				return true;
			}

			//Adds specialization from EmployeeSpecialization table
            if (employee.Specializations.Count() > foundEmployee.Specializations.Count())
            {
				if (!foundEmployee.Specializations.Exists(s => s.SpecializationId == employee.Specializations.Last().SpecializationId)) //Extra validation, checks new specialization already exist/is assigned on employee from database
                {
                    foundEmployee.Specializations.Add(employee.Specializations.Last());
					db.SaveChanges();
					return true;
                }
            }

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
				employees = db.Employees.Include(s => s.Specializations).ToList();
			}
			catch
			{
				employees = new List<Employee>();
			}
			return employees;
		}
	}
}

