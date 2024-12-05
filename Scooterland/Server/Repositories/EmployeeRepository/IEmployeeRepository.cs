using Scooterland.Shared.Models;

namespace Scooterland.Server.Repositories.EmployeeRepository
{
	public interface IEmployeeRepository
	{
		List<Employee> GetAllEmployees();
		Employee FindEmployee(int id);
		void AddEmployee(Employee employee);
		bool DeleteEmployee(int id);
		bool UpdateEmployee(Employee employee);
	}
}
