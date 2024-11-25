using Scooterland.Shared.Models;

namespace Scooterland.Client.Services.ProductServices
{
	public interface IProductService
	{
        Task<Product[]?> GetAllProducts();

        Task<Product?> GetProduct(int id);

        Task<int> AddProduct(Product product);

        Task<int> DeleteProduct(int id);

        Task<int> UpdateProduct(Product product);
    }
}
