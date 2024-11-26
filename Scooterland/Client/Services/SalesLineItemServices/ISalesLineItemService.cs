using Scooterland.Shared.Models;

namespace Scooterland.Client.Services.SalesLineItemServices
{
	public interface ISalesLineItemService
	{
		Task<SalesLineItem[]?> GetAllSalesLineItem();

		Task<SalesLineItem?> GetSalesLineItem(int id);

		Task<int> AddSalesLineItem(SalesLineItem salesLineItem);

		Task<int> DeleteSalesLineItem(int id);

		Task<int> UpdateSalesLineItem(SalesLineItem salesLineItem);
	}
}
