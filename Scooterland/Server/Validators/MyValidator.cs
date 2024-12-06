using Scooterland.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace Scooterland.Server.Validators
{
    public class MyValidator
    {
        internal bool CustomerValidation(Customer customer)
        {
            if (customer == null)
            {
                Console.WriteLine($"Customer is null");
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
    }
}
