using Microsoft.EntityFrameworkCore;
using Scooterland.Server.DataAccess;
using Scooterland.Server.Validators;
using Scooterland.Shared.Models;

namespace Scooterland.Server.Repositories.SalesLineItemRepository
{
	public class SalesLineItemRepositoryEF : ISalesLineItemRepository
	{
		public void AddSalesLineItem(SalesLineItem salesLineItem)
		{
            var validation = new MyValidator();
            bool isValid = validation.SalesLineItemValidation(salesLineItem);
            if (isValid)
			{
				try
				{
					var db = new ScooterlandDbContext();
					db.SalesLineItems.Add(salesLineItem);
					db.SaveChanges();
				}
				catch (Exception ex)
				{
                    
				}
			}
		}

		public bool DeleteSalesLineItem(int id)
		{
			try
			{
				int counterBefore = 0;
				int counterAfter = 0;
				var db = new ScooterlandDbContext();
				SalesLineItem salesLineItem;
				salesLineItem = db.SalesLineItems.Where(x => x.SalesLineItemId == id).FirstOrDefault();
				if (id == salesLineItem.SalesLineItemId)
				{
					counterBefore = db.SalesLineItems.Count();
					db.SalesLineItems.Remove(salesLineItem);
					db.SaveChanges();
					counterAfter = db.SalesLineItems.Count();
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


		public bool UpdateSalesLineItem(SalesLineItem salesLineItem)
		{
			try
			{
				var db = new ScooterlandDbContext();
				SalesLineItem foundSalesLineItem = db.SalesLineItems.Where(x => x.SalesLineItemId == salesLineItem.SalesLineItemId).FirstOrDefault();

				if (foundSalesLineItem == null)
				{
					return false;
				}

				foundSalesLineItem.Quantity = salesLineItem.Quantity;
				foundSalesLineItem.Discount = salesLineItem.Discount;
				db.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
               
				return false;
			}
		}


		//return item with id = -1 if not found
		public SalesLineItem FindSalesLineItem(int id)
		{
			var db = new ScooterlandDbContext();
			SalesLineItem salesLineItem;
			try
			{
				salesLineItem = db.SalesLineItems.Where(x => x.SalesLineItemId == id).FirstOrDefault();
			}
			catch
			{
				salesLineItem = new SalesLineItem(-1);
			}

			return salesLineItem;
		}

		public List<SalesLineItem> GetAllSalesLineItem()
		{
			var db = new ScooterlandDbContext();
			List<SalesLineItem> salesLineItems;
			try
			{
				salesLineItems = db.SalesLineItems.Include(salesLineItems => salesLineItems.Product).ToList();
			}
			catch
			{
				salesLineItems = new List<SalesLineItem>();
			}
			return salesLineItems;
		}
	}
}
