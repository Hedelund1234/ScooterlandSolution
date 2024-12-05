using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Scooterland.Server.Repositories.ProductRepository;
using Scooterland.Shared.Models;

namespace Scooterland.Server.Controllers
{
	[Route("api/productapi")]
	[ApiController]
	public class ProductController : ControllerBase
	{
        private readonly IProductRepository Repository = new ProductRepositoryEF();
        private readonly IProductRepository SQLRepository = new ProductRepositorySQLClient(); //Bliver kun brugt ved GetAllProducts


        public ProductController(IProductRepository productRepository)
        {
            if (Repository == null && productRepository != null)
            {
                Repository = productRepository;
                Console.WriteLine("Repository initialized");
            }
        }


		[HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            //return Repository.GetAllProducts();
            return SQLRepository.GetAllProducts(); //Her blive SQLRepository brugt istedet
        }

        [HttpDelete("{id:int}")]
        public StatusCodeResult DeleteProduct(int id)
        {
            Console.WriteLine("Server: Delete product called: id = " + id);

            bool deleted = Repository.DeleteProduct(id);
            if (deleted)
            {
                Console.WriteLine("Server: Product deleted succces");
                int code = (int)HttpStatusCode.OK;
                return new StatusCodeResult(code);
            }
            else
            {
                Console.WriteLine("Server: Product deleted fail - not found");
                int code = (int)HttpStatusCode.NotFound;
                return new StatusCodeResult(code);
            }
        }

        [HttpPost]
        public void AddProduct(Product product)
        {
            Console.WriteLine("Add product called: " + product.ToString());
            Repository.AddProduct(product);
        }



        [HttpGet("{id:int}")]
        public Product FindProduct(int id)
        {
            var result = Repository.FindProduct(id);
            return result;
        }

        [HttpPatch]
        public StatusCodeResult UpdateProduct(Product product)
        {
            bool updated = Repository.UpdateProduct(product);
            if (updated)
            {
                Console.WriteLine("Server: Product updated succces");
                int code = (int)HttpStatusCode.OK;
                return new StatusCodeResult(code);
            }
            else
            {
                Console.WriteLine("Server: Product updated fail - something went wrong");
                int code = (int)HttpStatusCode.NotFound;
                return new StatusCodeResult(code);
            }
        }
    }
}
