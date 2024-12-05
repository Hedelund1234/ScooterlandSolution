using Scooterland.Shared.Models;

namespace Scooterland.Server.Repositories.SpecializationRepository
{
	public interface ISpecializationRepository
	{
		List<Specialization> GetAllSpecialization();
		Specialization FindSpecialization(int id);
		void AddSpecialization(Specialization specialization);
		bool DeleteSpecialization(int id);
		bool UpdateSpecialization(Specialization specialization);
	}
}
