using Scooterland.Server.Repositories.EmployeeRepository;
using Scooterland.Shared.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Scooterland.Server.Validators
{
    public class MyValidator
    {
        internal bool CustomerValidation(Customer customer)
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
            return true;
        }

        internal bool EmployeeValidation(Employee employee)
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

        internal bool ProductValidation(Product product)
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

        internal bool SaleValidation(Sale sale)
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

        internal bool SalesLineItemValidation(SalesLineItem salesLineItem)
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

        internal bool SpecializationValidation(Specialization specialization)
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


        //[JsonIgnore]
        //public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
