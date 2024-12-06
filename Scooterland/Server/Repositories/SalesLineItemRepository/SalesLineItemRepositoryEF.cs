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
            bool isValid = validation.SalesLineItemCreateValidation(salesLineItem);
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
				int changed = 0;
				var db = new ScooterlandDbContext();
				SalesLineItem salesLineItem;
				salesLineItem = db.SalesLineItems.Where(x => x.SalesLineItemId == id).FirstOrDefault();
				if (id == salesLineItem.SalesLineItemId)
				{
					db.SalesLineItems.Remove(salesLineItem);
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


		public bool UpdateSalesLineItem(SalesLineItem salesLineItem)
		{
            var validation = new MyValidator();
            bool isValid = validation.SalesLineItemUpdateValidation(salesLineItem);
            if (isValid)
			{
                try
                {
                    var db = new ScooterlandDbContext();
                    SalesLineItem foundSalesLineItem = db.SalesLineItems.Where(x => x.SalesLineItemId == salesLineItem.SalesLineItemId).FirstOrDefault();

                    if (foundSalesLineItem == null)
                    {
                        return false;
                    }

                    if (salesLineItem.Quantity == foundSalesLineItem.Quantity &&
                        salesLineItem.Discount == foundSalesLineItem.Discount)
                    {
                        return true;
                    }

                    foundSalesLineItem.Quantity = salesLineItem.Quantity;
                    foundSalesLineItem.Discount = salesLineItem.Discount;
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
