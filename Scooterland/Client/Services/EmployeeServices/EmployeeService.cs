using Scooterland.Shared.Models;
using System.Net.Http.Json;

namespace Scooterland.Client.Services.EmployeeServices
{
	public class EmployeeService : IEmployeeService
	{
        private readonly HttpClient httpClient;


        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<Employee[]?> GetAllEmployees()
        {
            var result = httpClient.GetFromJsonAsync<Employee[]>("api/employeeapi");

            return result;
        }

        public async Task<Employee?> GetEmployee(int id)
        {
            var result = await httpClient.GetFromJsonAsync<Employee>("api/employeeapi/" + id);

            return result;
        }

        public async Task<int> AddEmployee(Employee employee)
        {
            var response = await httpClient.PostAsJsonAsync("api/employeeapi", employee);

            var responseStatusCode = response.StatusCode;

            return (int)responseStatusCode;
        }

        public async Task<int> DeleteEmployee(int id)
        {
            var response = await httpClient.DeleteAsync("api/employeeapi/" + id);

            var responseStatusCode = response.StatusCode;

            return (int)responseStatusCode;
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            var response = await httpClient.PatchAsJsonAsync("api/employeeapi", employee);

            var responseStatusCode = response.StatusCode;

            return (int)responseStatusCode;
        }

    }
}
