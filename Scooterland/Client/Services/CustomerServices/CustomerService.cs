using Scooterland.Shared.Models;
using System.Net.Http.Json;

namespace Scooterland.Client.Services.CustomerServices
{
	public class CustomerService : ICustomerService
	{
		private readonly HttpClient httpClient;


		public CustomerService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public Task<Customer[]?> GetAllCustomers()
		{
			var result = httpClient.GetFromJsonAsync<Customer[]>("api/customerapi");

			return result;
		}

		public async Task<Customer?> GetCustomer(int id)
		{
			var result = await httpClient.GetFromJsonAsync<Customer>("api/customerapi/" + id);

			return result;
		}

		public async Task<int> AddCustomer(Customer customer)
		{
			var response = await httpClient.PostAsJsonAsync("api/customerapi", customer);

			var responseStatusCode = response.StatusCode;

			return (int)responseStatusCode;
		}

		public async Task<int> DeleteCustomer(int id)
		{
			var response = await httpClient.DeleteAsync("api/customerapi/" + id);

			var responseStatusCode = response.StatusCode;

			return (int)responseStatusCode;
		}

		public async Task<int> UpdateCustomer(Customer customer)
		{
			var response = await httpClient.PatchAsJsonAsync("api/customerapi", customer);

			var responseStatusCode = response.StatusCode;

			return (int)responseStatusCode;
		}
	}
}
