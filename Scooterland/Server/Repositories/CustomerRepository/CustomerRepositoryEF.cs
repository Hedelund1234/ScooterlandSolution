using Scooterland.Server.DataAccess;
using Scooterland.Server.Validators;
using Scooterland.Shared.Models;

namespace Scooterland.Server.Repositories.CustomerRepository
{
	public class CustomerRepositoryEF : ICustomerRepository
	{
		public void AddCustomer(Customer customer)
		{
			var validation = new MyValidator();
			bool isValid = validation.CustomerValidation(customer);
			if (isValid)
			{
				try
				{
					var db = new ScooterlandDbContext();
					db.Customers.Add(customer);
					db.SaveChanges();
				}
				catch (Exception ex)
				{
                    
				}
			}
		}

		public bool DeleteCustomer(int id)
		{
			try
			{
				int counterBefore = 0;
				int counterAfter = 0;
				var db = new ScooterlandDbContext();
				Customer customer;
				customer = db.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
				if (id == customer.CustomerId)
				{
					counterBefore = db.Customers.Count();
					db.Customers.Remove(customer);
					db.SaveChanges();
					counterAfter = db.Customers.Count();
				}
				if (counterBefore < counterAfter)
				{
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
                
				return false;
			}
		}


		public bool UpdateCustomer(Customer customer)
		{
			try
			{
				var db = new ScooterlandDbContext();
				Customer foundCustomer = db.Customers.Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault();

				var originalCustomer = foundCustomer;

				foundCustomer.Name = customer.Name;
				foundCustomer.Email = customer.Email;
				foundCustomer.Phonenumber = customer.Phonenumber;
				foundCustomer.Address = customer.Address;
				db.SaveChanges();

				if (originalCustomer.Name != foundCustomer.Name ||
					originalCustomer.Email != foundCustomer.Email ||
					originalCustomer.Phonenumber != foundCustomer.Phonenumber ||
					originalCustomer.Address != foundCustomer.Address)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception ex)
			{
                
				return false;
			}
		}


		//return item with id = -1 if not found
		public Customer FindCustomer(int id)
		{
			var db = new ScooterlandDbContext();
			Customer customer;
			try
			{
				customer = db.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
			}
			catch
			{
				customer = new Customer(-1);
			}

			return customer;
		}

		public List<Customer> GetAllCustomers()
		{
			var db = new ScooterlandDbContext();
			List<Customer> customers;
			try
			{
				customers = db.Customers.ToList();
			}
			catch
			{
				customers = new List<Customer>();
			}
			return customers;
		}
	}
}
