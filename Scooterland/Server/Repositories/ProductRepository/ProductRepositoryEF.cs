using Microsoft.EntityFrameworkCore;
using Scooterland.Server.DataAccess;
using Scooterland.Server.Validators;
using Scooterland.Shared.Models;

namespace Scooterland.Server.Repositories.ProductRepository
{
	public class ProductRepositoryEF : IProductRepository
	{
        public void AddProduct(Product product)
        {
            var validation = new MyValidator();
            bool isValid = validation.ProductCreateValidation(product);
            if (isValid)
            {
                try
                {
                    var db = new ScooterlandDbContext();
                    db.Products.Add(product);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    
                }
            }
        }
        public bool DeleteProduct(int id)
        {
            try
            {
                int changed = 0;
                var db = new ScooterlandDbContext();
                Product product;
                product = db.Products.Where(x => x.ProductId == id).FirstOrDefault();
                if (id == product.ProductId)
                {
                    db.Products.Remove(product);
                    changed = db.SaveChanges();
                }
                if (changed > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }
        public bool UpdateProduct(Product product)
        {
            var validation = new MyValidator();
            bool isValid = validation.ProductUpdateValidation(product);
            if (isValid)
            {
                try
                {
                    var db = new ScooterlandDbContext();
                    Product foundProduct = db.Products.Where(x => x.ProductId == product.ProductId).FirstOrDefault();

                    if (foundProduct == null)
                    {
                        return false;
                    }

                    if (product.Name == foundProduct.Name &&
                        product.Price == foundProduct.Price &&
                        product.Type == foundProduct.Type)
                    {
                        return true;
                    }

                    foundProduct.Name = product.Name;
                    foundProduct.Price = product.Price;
                    foundProduct.Type = product.Type;
                    int changed = db.SaveChanges();

                    if (changed > 0)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
            return false;
        }
        public Product FindProduct(int id)
		{ //return item with id = -1 if not found
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

