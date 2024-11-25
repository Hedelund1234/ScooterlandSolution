using Microsoft.EntityFrameworkCore;
using Scooterland.Server.DataAccess;
using Scooterland.Shared.Models;

namespace Scooterland.Server.Repositories.ProductRepository
{
	public class ProductRepositoryEF : IProductRepository
	{
        public bool AddProduct(Product product)
        {
            var db = new ScooterlandDbContext();
            int counterBefore = db.Products.Count();
            db.Products.Add(product);
            db.SaveChanges();
            int counterAfter = db.Products.Count();

            if (counterBefore < counterAfter)
            {
                return true;
            }
            return false;

        }

        public bool DeleteProduct(int id)
        {
            int counterBefore = 0;
            int counterAfter = 0;
            var db = new ScooterlandDbContext();
            Product product;
            product = db.Products.Where(x => x.ProductId == id).FirstOrDefault();
            if (id == product.ProductId)
            {
                counterBefore = db.Products.Count();
                db.Products.Remove(product);
                db.SaveChanges();
                counterAfter = db.Products.Count();
            }
            if (counterBefore < counterAfter)
            {
                return true;
            }
            return false;
        }


        public bool UpdateProduct(Product product)
        {
            var db = new ScooterlandDbContext();
            Product foundProduct = db.Products.Where(x => x.ProductId == product.ProductId).FirstOrDefault();

            var originalProduct = foundProduct;

            foundProduct.Name = product.Name;
            foundProduct.Price = product.Price;
            foundProduct.Type = product.Type;
            db.SaveChanges();

            if (originalProduct.Name != foundProduct.Name ||
                originalProduct.Price != foundProduct.Price ||
                originalProduct.Type != foundProduct.Type)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //return item with id = -1 if not found
        public Product FindProduct(int id)
        {
            var db = new ScooterlandDbContext();
            Product product;
            try
            {
                product = db.Products.Where(x => x.ProductId == id).FirstOrDefault();
            }
            catch
            {
                product = new Product(-1);
            }

            return product;
        }

        public List<Product> GetAllProducts()
        {
            var db = new ScooterlandDbContext();
            List<Product> products;
            try
            {
                products = db.Products.ToList();
            }
            catch
            {
                products = new List<Product>();
            }
            return products;
        }
    }
}
