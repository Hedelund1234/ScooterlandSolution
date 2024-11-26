using Scooterland.Shared.Models;
using System.Net.Http.Json;

namespace Scooterland.Client.Services.SalesLineItemServices
{
	public class SalesLineItemService : ISalesLineItemService
	{
		private readonly HttpClient httpClient;


		public SalesLineItemService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public Task<SalesLineItem[]?> GetAllSalesLineItem()
		{
			var result = httpClient.GetFromJsonAsync<SalesLineItem[]>("api/salesLineItemapi");

			return result;
		}

		public async Task<SalesLineItem?> GetSalesLineItem(int id)
		{
			var result = await httpClient.GetFromJsonAsync<SalesLineItem>("api/salesLineItemapi/" + id);

			return result;
		}

		public async Task<int> AddSalesLineItem(SalesLineItem salesLineItem)
		{
			var response = await httpClient.PostAsJsonAsync("api/salesLineItemapi", salesLineItem);

			var responseStatusCode = response.StatusCode;

			return (int)responseStatusCode;
		}

		public async Task<int> DeleteSalesLineItem(int id)
		{
			var response = await httpClient.DeleteAsync("api/salesLineItemapi/" + id);

			var responseStatusCode = response.StatusCode;

			return (int)responseStatusCode;
		}

		public async Task<int> UpdateSalesLineItem(SalesLineItem salesLineItem)
		{
			var response = await httpClient.PatchAsJsonAsync("api/salesLineItemapi", salesLineItem);

			var responseStatusCode = response.StatusCode;

			return (int)responseStatusCode;
		}
	}
}
