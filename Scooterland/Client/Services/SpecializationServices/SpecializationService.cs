using Scooterland.Shared.Models;
using System.Net.Http.Json;

namespace Scooterland.Client.Services.SpecializationServices
{
	public class SpecializationService : ISpecializationService
	{
		private readonly HttpClient httpClient;


		public SpecializationService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public Task<Specialization[]?> GetAllSpecialization()
		{
			var result = httpClient.GetFromJsonAsync<Specialization[]>("api/specializationapi");

			return result;
		}

		public async Task<Specialization?> GetSpecialization(int id)
		{
			var result = await httpClient.GetFromJsonAsync<Specialization>("api/specializationapi/" + id);

			return result;
		}

		public async Task<int> AddSpecialization(Specialization specialization)
		{
			var response = await httpClient.PostAsJsonAsync("api/specializationapi", specialization);

			var responseStatusCode = response.StatusCode;

			return (int)responseStatusCode;
		}

		public async Task<int> DeleteSpecialization(int id)
		{
			var response = await httpClient.DeleteAsync("api/specializationapi/" + id);

			var responseStatusCode = response.StatusCode;

			return (int)responseStatusCode;
		}

		public async Task<int> UpdateSpecialization(Specialization specialization)
		{
			var response = await httpClient.PatchAsJsonAsync("api/specializationapi", specialization);

			var responseStatusCode = response.StatusCode;

			return (int)responseStatusCode;
		}
	}
}
