using Scooterland.Shared.Models;

namespace Scooterland.Server.Repositories.CustomerRepository
{
	public interface ICustomerRepository
	{
		List<Customer> GetAllCustomers();
		Customer FindCustomer(int id);
		void AddCustomer(Customer customer);
		bool DeleteCustomer(int id);
		bool UpdateCustomer(Customer customer);
	}
}
