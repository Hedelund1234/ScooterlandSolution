using Scooterland.Shared.Models;

namespace Scooterland.Server.Repositories.SalesLineItemRepository
{
	public interface ISalesLineItemRepository
	{
		List<SalesLineItem> GetAllSalesLineItem();
		SalesLineItem FindSalesLineItem(int id);
		void AddSalesLineItem(SalesLineItem salesLineItem);
		bool DeleteSalesLineItem(int id);
		bool UpdateSalesLineItem(SalesLineItem salesLineItem);
	}
}
