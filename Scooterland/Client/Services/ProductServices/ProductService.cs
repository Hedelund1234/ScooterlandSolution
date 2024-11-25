using System.Net.Http.Json;
using Scooterland.Shared.Models;

namespace Scooterland.Client.Services.ProductServices
{
	public class ProductService : IProductService
	{
        private readonly HttpClient httpClient;


        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<Product[]?> GetAllProducts()
        {
            var result = httpClient.GetFromJsonAsync<Product[]>("api/productapi");

            return result;
        }

        public async Task<Product?> GetProduct(int id)
        {
            var result = await httpClient.GetFromJsonAsync<Product>("api/productapi/" + id);

            return result;
        }

        public async Task<int> AddProduct(Product product)
        {
            var response = await httpClient.PostAsJsonAsync("api/productapi", product);

            var responseStatusCode = response.StatusCode;

            return (int)responseStatusCode;
        }

        public async Task<int> DeleteProduct(int id)
        {
            var response = await httpClient.DeleteAsync("api/productapi/" + id);

            var responseStatusCode = response.StatusCode;

            return (int)responseStatusCode;
        }

        public async Task<int> UpdateProduct(Product product)
        {
            var response = await httpClient.PatchAsJsonAsync("api/productapi", product);

            var responseStatusCode = response.StatusCode;

            return (int)responseStatusCode;
        }
    }
}
