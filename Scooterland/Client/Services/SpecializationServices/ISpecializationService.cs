using Scooterland.Shared.Models;

namespace Scooterland.Client.Services.SpecializationServices
{
	public interface ISpecializationService
	{
		Task<Specialization[]?> GetAllSpecialization();

		Task<Specialization?> GetSpecialization(int id);

		Task<int> AddSpecialization(Specialization specialization);

		Task<int> DeleteSpecialization(int id);

		Task<int> UpdateSpecialization(Specialization specialization);
	}
}
