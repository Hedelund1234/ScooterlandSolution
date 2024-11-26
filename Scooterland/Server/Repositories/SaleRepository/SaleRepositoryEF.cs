﻿using Scooterland.Server.DataAccess;
using Scooterland.Shared.Models;

namespace Scooterland.Server.Repositories.SaleRepository
{
	public class SaleRepositoryEF : ISaleRepository
	{
        public bool AddSale(Sale sale)
        {
            var db = new ScooterlandDbContext();
            int counterBefore = db.Sales.Count();
            db.Sales.Add(sale);
            db.SaveChanges();
            int counterAfter = db.Sales.Count();

            if (counterBefore < counterAfter)
            {
                return true;
            }
            return false;

        }

        public bool DeleteSale(int id)
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


        public bool UpdateSale(Sale sale)
        {
            var db = new ScooterlandDbContext();
            Sale foundSale = db.Sales.Where(x => x.SaleId == sale.SaleId).FirstOrDefault();

            var originalSale = foundSale;

            foundSale.EndDate = sale.EndDate;
            foundSale.Payment = sale.Payment;
            db.SaveChanges();

            if (originalSale.EndDate != foundSale.EndDate ||
                originalSale.Payment != foundSale.Payment)
            {
                return true;
            }
            else
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
                sale = db.Sales.Where(x => x.SaleId == id).FirstOrDefault();
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
            List<Sale> sale;
            try
            {
                sale = db.Sales.ToList();
            }
            catch
            {
                sale = new List<Sale>();
            }
            return sale;
        }
    }
}
