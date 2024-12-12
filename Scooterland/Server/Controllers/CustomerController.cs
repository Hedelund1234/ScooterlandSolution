using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scooterland.Server.Repositories.CustomerRepository;
using Scooterland.Shared.Models;
using System.Net;

namespace Scooterland.Server.Controllers
{
	[Route("api/customerapi")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerRepository Repository = new CustomerRepositoryEF();


		public CustomerController(ICustomerRepository customerRepository)
		{
			if (Repository == null && customerRepository != null)
			{
				Repository = customerRepository;
				Console.WriteLine("Repository initialized");
			}
		}

		[HttpGet]
		public IEnumerable<Customer> GetAllCustomers()
		{
			return Repository.GetAllCustomers();
		}

		[HttpDelete("{id:int}")]
		public StatusCodeResult DeleteCustomer(int id)
		{
			Console.WriteLine("Server: Delete customer called: id = " + id);

			bool deleted = Repository.DeleteCustomer(id);
			if (deleted)
			{
				Console.WriteLine("Server: Customer deleted succces");
				int code = (int)HttpStatusCode.OK;
				return new StatusCodeResult(code);
			}
			else
			{
				Console.WriteLine("Server: Customer deleted fail - not found");
				int code = (int)HttpStatusCode.NotFound;
				return new StatusCodeResult(code);
			}
		}

		[HttpPost]
		public void AddCustomer(Customer customer)
		{
			Console.WriteLine("Add customer called: " + customer.ToString());
			Repository.AddCustomer(customer);
		}

		[HttpGet("{id:int}")]
		public Customer FindCustomer(int id)
		{
			var result = Repository.FindCustomer(id);
			return result;
		}

		[HttpPatch]
		public StatusCodeResult UpdateCustomer(Customer customer)
		{
			bool updated = Repository.UpdateCustomer(customer);
			if (updated)
			{
				Console.WriteLine("Server: Customer updated succces");
				int code = (int)HttpStatusCode.OK;
				return new StatusCodeResult(code);
			}
			else
			{
				Console.WriteLine("Server: Customer updated fail - something went wrong");
				int code = (int)HttpStatusCode.NotFound;
				return new StatusCodeResult(code);
			}
		}
	}
}
