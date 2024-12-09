using Scooterland.Server.Repositories.CustomerRepository;
using Scooterland.Server.Repositories.EmployeeRepository;
using Scooterland.Shared.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Scooterland.Server.Validators
{
    public class MyValidator
    {
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                                                                                 //
        //                                                           This Page contains all validators for repositories                                                    //
        //                                              Does Not contains client side validation (only server side / the api calls                                         //
        //                                                                                                                                                                 //
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////////////////////////////////////////
        //                                       Customers                                       //
        ///////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// This method checks if entity matches Logic and database requirements when creating a customer 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Returns true if success</returns>
        public bool CustomerCreateValidation(Customer customer)
        {
            if (customer.CustomerId != 0)
            {
                Console.WriteLine("SOMETHING WENT WRONG - CustomerId can't be set due to database setup");
                return false;
            }
            if (customer == null)
            {
                Console.WriteLine("SOMETHING WENT WRONG - Customer is null");
                return false;
            }
            if (customer.Name.Length > 70)
            {
                Console.WriteLine($"SOMETHING WENT WRONG - Name too long for database: is {customer.Name.Length} max length is 70");
                return false;
            }
            if (customer.Email.Length > 100)
            {
                Console.WriteLine($"SOMETHING WENT WRONG - Email too long for database: is {customer.Email.Length} max length is 100");
                return false;
            }
            if (customer.Phonenumber.Length > 20)
            {
                Console.WriteLine($"SOMETHING WENT WRONG - Phonenumber too long for database: is {customer.Phonenumber.Length} max length is 20");
                return false;
            }
            if (customer.Address.Length > 150)
            {
                Console.WriteLine($"SOMETHING WENT WRONG - Address too long for database: is {customer.Address.Length} max length is 150");
                return false;
            }
			CustomerRepositoryEF repo = new CustomerRepositoryEF();
			List<Customer> allCustomers = repo.GetAllCustomers();
			if (allCustomers.Any(x => x.Email == customer.Email))
			{
				Console.WriteLine($"SOMETHING WENT WRONG - Email already exist in database");
				return false;
			}
			if (allCustomers.Any(x => x.Phonenumber == customer.Phonenumber))
			{
				Console.WriteLine($"SOMETHING WENT WRONG - Phonenumber already exist in database");
				return false;
			}
			return true;
        }
        /// <summary>
        /// This method checks if entity matches Logic and database requirements when updating a customer 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Returns true if success</returns>
        public bool CustomerUpdateValidation(Customer customer)
        {
            if (customer == null)
            {
                Console.WriteLine("SOMETHING WENT WRONG - Customer is null");
                return false;
            }
            if (customer.Name.Length > 70)
            {
                Console.WriteLine($"SOMETHING WENT WRONG - Name too long for database: is {customer.Name.Length} max length is 70");
                return false;
            }
            if (customer.Email.Length > 100)
            {
                Console.WriteLine($"SOMETHING WENT WRONG - Email too long for database: is {customer.Email.Length} max length is 100");
                return false;
            }
            if (customer.Phonenumber.Length > 20)
            {
                Console.WriteLine($"SOMETHING WENT WRONG - Phonenumber too long for database: is {customer.Phonenumber.Length} max length is 20");
                return false;
            }
            if (customer.Address.Length > 150)
            {
                Console.WriteLine($"SOMETHING WENT WRONG - Address too long for database: is {customer.Address.Length} max length is 150");
                return false;
            }
			CustomerRepositoryEF repo = new CustomerRepositoryEF();
			
            Customer customerOriginal = repo.FindCustomer(customer.CustomerId);
			List<Customer> allCustomers = repo.GetAllCustomers();
			if (customerOriginal.Phonenumber != customer.Phonenumber)
            {
				if (allCustomers.Any(x => x.Phonenumber == customer.Phonenumber))
				{
					Console.WriteLine($"SOMETHING WENT WRONG - Phonenumber already exist in database");
					return false;
				}
			}
			if (customerOriginal.Email != customer.Email)
			{
				if (allCustomers.Any(x => x.Email == customer.Email))
				{
					Console.WriteLine($"SOMETHING WENT WRONG - Email already exist in database");
					return false;
				}
			}
			return true;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        //                                       Employees                                       //
        ///////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// This method checks if entity matches Logic and database requirements when creating an employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Returns true if success</returns>
        public bool EmployeeCreateValidation(Employee employee)
        {
            if (employee.EmployeeId != 0)
            {
                Console.WriteLine("SOMETHING WENT WRONG - EmployeeId can't be set due to database setup");
                return false;
            }
            if (employee == null)
            {
                Console.WriteLine("SOMETHING WENT WRONG - Employee is null");
                return false;
            }
            if (employee.Name.Length > 70)
            {
                Console.WriteLine($"SOMETHING WENT WRONG - Name too long for database: is {employee.Name.Length} max length is 70");
                return false;
            }
            if (employee.Role.Length > 30)
            {
                Console.WriteLine($"SOMETHING WENT WRONG - Role too long for database: is {employee.Role.Length} max length is 30");
                return false;
            }
            if (employee.Specializations.Any())
            {
                Console.WriteLine("SOMETHING WENT WRONG - Can't create employee with specializations (must be added later)");
                return false;
            }
			return true;
        }

        /// <summary>
        /// This method checks if entity matches Logic and database requirements when updating an employee 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Returns true if success</returns>
        public bool EmployeeUpdateValidation(Employee employee)
        {
            if (employee == null)
            {
                Console.WriteLine("SOMETHING WENT WRONG - Employee is null");
                return false;
            }
            if (employee.Name.Length > 70)
            {
                Console.WriteLine($"SOMETHING WENT WRONG - Name too long for database: is {employee.Name.Length} max length is 70");
                return false;
            }
            if (employee.Role.Length > 30)
            {
                Console.WriteLine($"SOMETHING WENT WRONG - Role too long for database: is {employee.Role.Length} max length is 30");
                return false;
            }
            return true;
        }



        ///////////////////////////////////////////////////////////////////////////////////////////
        //                                       Products                                        //
        ///////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// This method checks if entity matches Logic and database requirements when creating a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Returns true if success</returns>
        public bool ProductCreateValidation(Product product)
        {
            if (product.ProductId != 0)
            {
                Console.WriteLine("SOMETHING WENT WRONG - ProductId can't be set due to database setup");
                return false;
            }
            if (product == null)
            {
                Console.WriteLine("SOMETHING WENT WRONG - Product is null");
                return false;
            }
            if (product.Name.Length > 70)
            {
                Console.WriteLine($"SOMETHING WENT WRONG - Name too long for database: is {product.Name.Length} max length is 70");
                return false;
            }
            if (product.Type.Length > 30)
            {
                Console.WriteLine($"SOMETHING WENT WRONG - Type too long for database: is {product.Type.Length} max length is 30");
                return false;
            }
            if (product.Price < 0 || product.Price > int.MaxValue)
            {
                Console.WriteLine($"SOMETHING WENT WRONG - Price too long or negative for database: is {product.Type.Length} should be between 0 - {int.MaxValue}");
                return false;
            }
            return true;
        }

        /// <summary>
        /// This method checks if entity matches Logic and database requirements when updating a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Returns true if success</returns>
        public bool ProductUpdateValidation(Product product)
        {
            if (product == null)
            {
                Console.WriteLine("SOMETHING WENT WRONG - Product is null");
                return false;
            }
            if (product.Name.Length > 70)
            {
                Console.WriteLine($"SOMETHING WENT WRONG - Name too long for database: is {product.Name.Length} max length is 70");
                return false;
            }
            if (product.Type.Length > 30)
            {
                Console.WriteLine($"SOMETHING WENT WRONG - Type too long for database: is {product.Type.Length} max length is 30");
                return false;
            }
            if (product.Price < 0 || product.Price > int.MaxValue)
            {
                Console.WriteLine($"SOMETHING WENT WRONG - Price too long or negative for database: is {product.Type.Length} should be between 0 - {int.MaxValue}");
                return false;
            }
            return true;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////
        //                                       Sales                                           //
        ///////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// This method checks if entity matches Logic and database requirements when creating a sale
        /// </summary>
        /// <param name="sale"></param>
        /// <returns>Returns true if success</returns>
        public bool SaleCreateValidation(Sale sale)
        {
            if (sale.SaleId != 0)
            {
                Console.WriteLine("SOMETHING WENT WRONG - SaleId can't be set due to database setup");
                return false;
            }
            if (sale == null)
            {
                Console.WriteLine("SOMETHING WENT WRONG - Sale is null");
                return false;
            }
            if (sale.CustomerId == null || sale.CustomerId <= 0 || sale.CustomerId > int.MaxValue || sale.Customer != null)
            {
                Console.WriteLine("SOMETHING WENT WRONG - Sale must have a valid customer connected");
                return false;
            }
            if (sale.EmployeeId != null || sale.Employee != null)
            {
                Console.WriteLine("SOMETHING WENT WRONG - Employee needs to be null");
                return false;
            }
            if (sale.EndDate != null)
            {
                Console.WriteLine("SOMETHING WENT WRONG - EndDate needs to be null");
                return false;
            }
            if (sale.SpecializationId != null || sale.Specialization != null)
            {
                Console.WriteLine("SOMETHING WENT WRONG - Specialization needs to be null");
                return false;
            }
            if (sale.StartDate < DateTime.MinValue || sale.StartDate > DateTime.MaxValue || sale.StartDate == null)
            {
                Console.WriteLine("SOMETHING WENT WRONG - Sale must have a startdate before added");
                return false;
            }
            if (sale.Comment != null)
            {
                Console.WriteLine("SOMETHING WENT WRONG - Comment must be null when creating sale");
                return false;
            }
            return true;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        //                                     SalesLineItems                                    //
        ///////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// This method checks if entity matches Logic and database requirements when creating a salesLineItem
        /// </summary>
        /// <param name="salesLineItem"></param>
        /// <returns>Returns true if success</returns>
        public bool SalesLineItemCreateValidation(SalesLineItem salesLineItem)
        {
            if (salesLineItem.SalesLineItemId != 0)
            {
                Console.WriteLine("SOMETHING WENT WRONG - SalesLineItem can't be set due to database setup");
                return false;
            }
            if (salesLineItem == null)
            {
                Console.WriteLine("SOMETHING WENT WRONG - SalesLineItem is null");
                return false;
            }
            if (salesLineItem.Discount != 0)
            {
                Console.WriteLine("SOMETHING WENT WRONG - Discount must be 0 when creating SalesLineItems");
                return false;
            }
            if (salesLineItem.Product != null)
            {
                Console.WriteLine("SOMETHING WENT WRONG - Product must be null when creating SalesLineItems");
                return false;
            }
            if (salesLineItem.ProductId <= 0 || salesLineItem.ProductId > int.MaxValue || salesLineItem.ProductId == null)
            {
                Console.WriteLine("SOMETHING WENT WRONG - SalesLineItem must have a valid ProductId to be created");
                return false;
            }
            if (salesLineItem.Quantity <= 0 || salesLineItem.Quantity > int.MaxValue || salesLineItem.Quantity == null)
            {
                Console.WriteLine("SOMETHING WENT WRONG - SalesLineItem must have a quantity over 0 to be created");
                return false;
            }
            if (salesLineItem.Sale != null)
            {
                Console.WriteLine("SOMETHING WENT WRONG - Sale must be null to create SalesLineItem");
                return false;
            }
            if (salesLineItem.SaleId <= 0 || salesLineItem.SaleId > int.MaxValue || salesLineItem.SaleId == null)
            {
                Console.WriteLine("SOMETHING WENT WRONG - SalesLineItem must have a valid saleId to be created");
                return false;
            }
            return true;
        }

        /// <summary>
        /// This method checks if entity matches Logic and database requirements when updating a salesLineItem
        /// </summary>
        /// <param name="salesLineItem"></param>
        /// <returns>Returns true if success</returns>
        public bool SalesLineItemUpdateValidation(SalesLineItem salesLineItem)
        {
            if (salesLineItem == null)
            {
                Console.WriteLine("SOMETHING WENT WRONG - SalesLineItem is null");
                return false;
            }
            if (salesLineItem.Quantity <= 0 || salesLineItem.Quantity > int.MaxValue || salesLineItem.Quantity == null)
            {
                Console.WriteLine("SOMETHING WENT WRONG - SalesLineItem must have a quantity over 0 to be updated");
                return false;
            }
            if (salesLineItem.Discount > 100 || salesLineItem.Discount < 0)
            {
                Console.WriteLine("SOMETHING WENT WRONG - Discount can't be greater than 100%");
                return false;
            }
            return true;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        //                                    Specializations                                    //
        ///////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// This method checks if entity matches Logic and database requirements when creating a specialization
        /// </summary>
        /// <param name="specialization"></param>
        /// <returns>Returns true if success</returns>
        public bool SpecializationCreateValidation(Specialization specialization)
        {
            if (specialization.SpecializationId != 0)
            {
                Console.WriteLine("SOMETHING WENT WRONG - SpecializationId must be 0");
                return false;
            }
            if (specialization == null)
            {
                Console.WriteLine("SOMETHING WENT WRONG - Specialization can't be null");
                return false;
            }
            if (specialization.Brand.Length > 30)
            {
                Console.WriteLine($"SOMETHING WENT WRONG - Brand too long for database: is {specialization.Brand.Length} max length is 30");
                return false;
            }
            if (specialization.Employees.Any())
            {
                Console.WriteLine("SOMETHING WENT WRONG - Specialization can't have employees being created");
                return false;
            }
            return true;
        }

        /// <summary>
        /// This method checks if entity matches Logic and database requirements when updating a specialization
        /// </summary>
        /// <param name="specialization"></param>
        /// <returns>Returns true if success</returns>
        public bool SpecializationUpdateValidation(Specialization specialization)
        {
            if (specialization == null)
            {
                Console.WriteLine("SOMETHING WENT WRONG - Specialization can't be null");
                return false;
            }
            if (specialization.Brand.Length > 30)
            {
                Console.WriteLine($"SOMETHING WENT WRONG - Brand too long for database: is {specialization.Brand.Length} max length is 30");
                return false;
            }
            return true;
        }

    }
}
