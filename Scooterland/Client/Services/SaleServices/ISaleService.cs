using Scooterland.Shared.Models;

namespace Scooterland.Client.Services.SaleServices
{
	public interface ISaleService
	{
        Task<Sale[]?> GetAllSales();

        Task<Sale?> GetSale(int id);

        Task<int> AddSale(Sale sale);

        Task<int> DeleteSale(int id);

        Task<int> UpdateSale(Sale sale);
    }
}
