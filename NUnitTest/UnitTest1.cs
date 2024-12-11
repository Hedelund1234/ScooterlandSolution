using Scooterland.Server.Repositories.CustomerRepository;
using Scooterland.Server.Repositories.EmployeeRepository;
using Scooterland.Server.Validators;
using Scooterland.Shared.Models;

namespace NUnitTest
{
    public class Tests
    {
		MyValidator validator;
		[SetUp]
        public void Setup()
        {
			validator = new MyValidator();
		}

		// Customer Test
		[Test]
		public void CreateCustomerValidationTest()
		{
            var mockCustomer = new Customer { CustomerId = 0, 
                                              Name = "Jens Christian",  
                                              Email = "Jens@mail.dk",
                                              Phonenumber = "12345789", 
                                              Address = "Kolding vej 2 - 6000 Kolding"
											};
            Assert.That(validator.CustomerCreateValidation(mockCustomer), Is.True);
		}

		[Test]
		public async Task CustomerGetAllRepoTest()
		{
            ICustomerRepository repo = new CustomerRepositoryEF();
			var customers = repo.GetAllCustomers();
            Assert.That(customers, Is.Not.Empty);
		}




		// Employee Test
		[Test]
		public void CreateEmployeeValidationTest()
		{
			var mockEmployee = new Employee
			{
				EmployeeId = 0,
				Name = "Lars Landevej",
				Role = "Mekaniker",
			};
			Assert.That(validator.EmployeeCreateValidation(mockEmployee), Is.True);
		}


		[Test]
		public async Task EmployeeGetAllRepoTest()
		{
			IEmployeeRepository repo = new EmployeeRepositoryEF();
			var employee = repo.GetAllEmployees();
			Assert.That(employee, Is.Not.Empty);
		}
	}
}