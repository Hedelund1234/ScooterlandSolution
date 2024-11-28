using Microsoft.EntityFrameworkCore;
using Scooterland.Server.DataAccess;
using Scooterland.Shared.Models;

namespace Scooterland.Server.Repositories.SalesLineItemRepository
{
	public class SalesLineItemRepositoryEF : ISalesLineItemRepository
	{
		public bool AddSalesLineItem(SalesLineItem salesLineItem)
		{
			var db = new ScooterlandDbContext();
			int counterBefore = db.SalesLineItems.Count();
			db.SalesLineItems.Add(salesLineItem);
			db.SaveChanges();
			int counterAfter = db.SalesLineItems.Count();

			if (counterBefore < counterAfter)
			{
				return true;
			}
			return false;

		}

		public bool DeleteSalesLineItem(int id)
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


		public bool UpdateSalesLineItem(SalesLineItem salesLineItem)
		{
			var db = new ScooterlandDbContext();
			SalesLineItem foundSalesLineItem = db.SalesLineItems.Where(x => x.SalesLineItemId == salesLineItem.SalesLineItemId).FirstOrDefault();

			var originalSalesLineItem = foundSalesLineItem;

			foundSalesLineItem.Quantity = salesLineItem.Quantity;
			foundSalesLineItem.Discount = salesLineItem.Discount;
			db.SaveChanges();

			if (originalSalesLineItem.Quantity != foundSalesLineItem.Quantity ||
				originalSalesLineItem.Discount != foundSalesLineItem.Discount)
			{
				return true;
			}
			else
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
				//salesLineItems = db.SalesLineItems.ToList();
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
