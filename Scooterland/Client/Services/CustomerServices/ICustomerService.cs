using Scooterland.Shared.Models;

namespace Scooterland.Client.Services.CustomerServices
{
	public interface ICustomerService
	{
		Task<Customer[]?> GetAllCustomers();

		Task<Customer?> GetCustomer(int id);

		Task<int> AddCustomer(Customer customer);

		Task<int> DeleteCustomer(int id);

		Task<int> UpdateCustomer(Customer customer);
	}
}
