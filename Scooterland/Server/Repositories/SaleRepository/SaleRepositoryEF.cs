using Microsoft.EntityFrameworkCore;
using Scooterland.Server.DataAccess;
using Scooterland.Server.Validators;
using Scooterland.Shared.Models;
using System.Linq;

namespace Scooterland.Server.Repositories.SaleRepository
{
	public class SaleRepositoryEF : ISaleRepository
	{
		public void AddSale(Sale sale)
		{
            var validation = new MyValidator();
            bool isValid = validation.SaleValidation(sale);
            if (isValid)
			{
				try
				{
					var db = new ScooterlandDbContext();
					db.Sales.Add(sale);
					db.SaveChanges();
				}
				catch (Exception ex)
				{
                    
				}
			}
		}

		public bool DeleteSale(int id)
		{
			try
			{
				int counterBefore = 0;
				int counterAfter = 0;
				var db = new ScooterlandDbContext();
				Sale sale;
				sale = db.Sales.Where(x => x.SaleId == id).FirstOrDefault();
				if (id == sale.SaleId)
				{
					counterBefore = db.Sales.Count();
					db.Sales.Remove(sale);
					db.SaveChanges();
					counterAfter = db.Sales.Count();
				}
				if (counterBefore < counterAfter)
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


		public bool UpdateSale(Sale sale)
		{
			try
			{
				var db = new ScooterlandDbContext();
				Sale foundSale = db.Sales.Where(x => x.SaleId == sale.SaleId).FirstOrDefault();

				if (foundSale == null)
				{
					return false;
				}

				foundSale.EndDate = sale.EndDate;
				foundSale.Comment = sale.Comment;
				foundSale.EmployeeId = sale.EmployeeId;
				foundSale.SpecializationId = sale.SpecializationId;

				db.SaveChanges();  //Hvis save lykkedes, returner true. 

				return true;
			}
			catch (Exception ex)
			{
                
				return false;
			}
		}


		//return item with id = -1 if not found
		public Sale FindSale(int id)
		{
			var db = new ScooterlandDbContext();
			Sale sale;
			try
			{
				sale = db.Sales.Where(sale => sale.SaleId == id).Include(sale => sale.Customer).FirstOrDefault();
			}
			catch
			{
				sale = new Sale(-1);
			}

			return sale;
		}

		public List<Sale> GetAllSales()
		{
			var db = new ScooterlandDbContext();
			List<Sale> sales;
			try
			{
				//sale = db.Sales.ToList();
				sales = db.Sales.Include(s => s.Customer)
								.Include(s => s.Employee)
								.Include(s => s.Specialization)
								.ToList();


			}
			catch
			{
				sales = new List<Sale>();
			}
			return sales;
		}
	}
}
