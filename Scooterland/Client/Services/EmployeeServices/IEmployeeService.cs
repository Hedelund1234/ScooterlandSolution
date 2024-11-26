using Scooterland.Shared.Models;

namespace Scooterland.Client.Services.EmployeeServices
{
	public interface IEmployeeService
	{
        Task<Employee[]?> GetAllEmployees();

        Task<Employee?> GetEmployee(int id);

        Task<int> AddEmployee(Employee employee);

        Task<int> DeleteEmployee(int id);

        Task<int> UpdateEmployee(Employee employee);
    }
}
