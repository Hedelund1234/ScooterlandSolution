using Scooterland.Shared.Models;

namespace Scooterland.Server.Repositories.ProductRepository
{
	public interface IProductRepository
	{
        List<Product> GetAllProducts();
        Product FindProduct(int id);
        bool AddProduct(Product product);
        bool DeleteProduct(int id);
        bool UpdateProduct(Product product);
    }
}
