using Microsoft.EntityFrameworkCore.Diagnostics;
using Scooterland.Server.DataAccess.SQLClient;
using Scooterland.Shared.Models;
using System.Data.SqlClient;

namespace Scooterland.Server.Repositories.ProductRepository
{
	public class ProductRepositorySQLClient : IProductRepository
	{
		string connStrings;
		public ProductRepositorySQLClient()
        {
			ConnectionHandlerSQLClient connectionHandler = new ConnectionHandlerSQLClient();
			connStrings = connectionHandler.GetConnectionString();
		}
        public void AddProduct(Product product)
		{
		}

		public bool DeleteProduct(int id)
		{
			return false;
		}


		public bool UpdateProduct(Product product)
		{
			return false;
		}


		//return item with id = -1 if not found
		public Product FindProduct(int id)
		{
			Product product = new Product(-1);
			return product;
		}

		public List<Product> GetAllProducts()
		{
			List<Product> productList = new List<Product>();
			Product product = new Product();
			string command = "SELECT * FROM Products";
			SqlConnection conn = new SqlConnection(connStrings);
			try
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand(command, conn);

				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					int productId = (int)reader["ProductId"];
					string name = (string)reader["Name"];
					string type = (string)reader["Type"];
					decimal price = (decimal)reader["Price"];
					product = new Product { ProductId = productId, Name = name, Type = type, Price = price };
					productList.Add(product);
				}
			}
			catch (Exception)
			{

			}
			finally
			{
				conn.Close();
			}
			return productList;
		}
	}
}
