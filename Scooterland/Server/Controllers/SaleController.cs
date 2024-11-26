using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scooterland.Server.Repositories.EmployeeRepository;
using Scooterland.Shared.Models;
using Scooterland.Server.Repositories.SaleRepository;
using System.Net;

namespace Scooterland.Server.Controllers
{
	[Route("api/saleapi")]
	[ApiController]
	public class SaleController : ControllerBase
	{
        private readonly ISaleRepository Repository = new SaleRepositoryEF();


        public SaleController(ISaleRepository saleRepository)
        {
            if (Repository == null && saleRepository != null)
            {
                Repository = saleRepository;
                Console.WriteLine("Repository initialized");
            }
        }


        [HttpGet]
        public IEnumerable<Sale> GetAllSales()
        {
            return Repository.GetAllSales();
        }

        [HttpDelete("{id:int}")]
        public StatusCodeResult DeleteSale(int id)
        {
            Console.WriteLine("Server: Delete sale called: id = " + id);

            bool deleted = Repository.DeleteSale(id);
            if (deleted)
            {
                Console.WriteLine("Server: sale deleted succces");
                int code = (int)HttpStatusCode.OK;
                return new StatusCodeResult(code);
            }
            else
            {
                Console.WriteLine("Server: sale deleted fail - not found");
                int code = (int)HttpStatusCode.NotFound;
                return new StatusCodeResult(code);
            }
        }

        [HttpPost]
        public void AddSale(Sale sale)
        {
            Console.WriteLine("Add sale called: " + sale.ToString());
            Repository.AddSale(sale);
        }



        [HttpGet("{id:int}")]
        public Sale FindSale(int id)
        {
            var result = Repository.FindSale(id);
            return result;
        }

        [HttpPatch]
        public StatusCodeResult UpdateSale(Sale sale)
        {
            bool updated = Repository.UpdateSale(sale);
            if (updated)
            {
                Console.WriteLine("Server: sale updated succces");
                int code = (int)HttpStatusCode.OK;
                return new StatusCodeResult(code);
            }
            else
            {
                Console.WriteLine("Server: sale updated fail - something went wrong");
                int code = (int)HttpStatusCode.NotFound;
                return new StatusCodeResult(code);
            }
        }
    }
}
