using Scooterland.Shared.Models;
using System.Net.Http.Json;

namespace Scooterland.Client.Services.SaleServices
{
	public class SaleService : ISaleService
	{
        private readonly HttpClient httpClient;


        public SaleService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<Sale[]?> GetAllSales()
        {
            var result = httpClient.GetFromJsonAsync<Sale[]>("api/saleapi");

            return result;
        }

        public async Task<Sale?> GetSale(int id)
        {
            var result = await httpClient.GetFromJsonAsync<Sale>("api/saleapi/" + id);

            return result;
        }

        public async Task<int> AddSale(Sale sale)
        {
            var response = await httpClient.PostAsJsonAsync("api/saleapi", sale);

            var responseStatusCode = response.StatusCode;

            return (int)responseStatusCode;
        }

        public async Task<int> DeleteSale(int id)
        {
            var response = await httpClient.DeleteAsync("api/saleapi/" + id);

            var responseStatusCode = response.StatusCode;

            return (int)responseStatusCode;
        }

        public async Task<int> UpdateSale(Sale sale)
        {
            var response = await httpClient.PatchAsJsonAsync("api/saleapi", sale);

            var responseStatusCode = response.StatusCode;

            return (int)responseStatusCode;
        }
    }
}
