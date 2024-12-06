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
            bool isValid = validation.SaleCreateValidation(sale);
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
				int changed = 0;
				var db = new ScooterlandDbContext();
				Sale sale;
				sale = db.Sales.Where(x => x.SaleId == id).FirstOrDefault();
				if (id == sale.SaleId)
				{
					db.Sales.Remove(sale);
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

				if (sale.StartDate == foundSale.StartDate &&
					sale.EndDate == foundSale.EndDate &&
					sale.Comment == foundSale.Comment &&
					sale.EmployeeId == foundSale.EmployeeId &&
					sale.SpecializationId == foundSale.SpecializationId)
				{
					return true;
				}

				foundSale.EndDate = sale.EndDate;
				foundSale.Comment = sale.Comment;
				foundSale.EmployeeId = sale.EmployeeId;
				foundSale.SpecializationId = sale.SpecializationId;

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
