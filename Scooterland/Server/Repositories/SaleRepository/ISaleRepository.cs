using Scooterland.Shared.Models;

namespace Scooterland.Server.Repositories.SaleRepository
{
	public interface ISaleRepository
	{
        List<Sale> GetAllSales();
        Sale FindSale(int id);
        void AddSale(Sale sale);
        bool DeleteSale(int id);
        bool UpdateSale(Sale sale);
    }
}
