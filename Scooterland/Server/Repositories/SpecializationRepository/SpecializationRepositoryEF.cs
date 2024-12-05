using Scooterland.Server.DataAccess;
using Scooterland.Shared.Models;

namespace Scooterland.Server.Repositories.SpecializationRepository
{
	public class SpecializationRepositoryEF : ISpecializationRepository
	{
		public void AddSpecialization(Specialization specialization)
		{
			var db = new ScooterlandDbContext();
			db.Specializations.Add(specialization);
			db.SaveChanges();
        }

		public bool DeleteSpecialization(int id)
		{
			int counterBefore = 0;
			int counterAfter = 0;
			var db = new ScooterlandDbContext();
			Specialization specialization;
			specialization = db.Specializations.Where(x => x.SpecializationId == id).FirstOrDefault();
			if (id == specialization.SpecializationId)
			{
				counterBefore = db.Specializations.Count();
				db.Specializations.Remove(specialization);
				db.SaveChanges();
				counterAfter = db.Specializations.Count();
			}
			if (counterBefore < counterAfter)
			{
				return true;
			}
			return false;
		}


		public bool UpdateSpecialization(Specialization specialization)
		{
			var db = new ScooterlandDbContext();
			Specialization foundSpecialization = db.Specializations.Where(x => x.SpecializationId == specialization.SpecializationId).FirstOrDefault();

			var originalSpecialization = foundSpecialization;

			foundSpecialization.Brand = specialization.Brand;
			db.SaveChanges();

			if (originalSpecialization.Brand != foundSpecialization.Brand)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		//return item with id = -1 if not found
		public Specialization FindSpecialization(int id)
		{
			var db = new ScooterlandDbContext();
			Specialization specialization;
			try
			{
				specialization = db.Specializations.Where(x => x.SpecializationId == id).FirstOrDefault();
			}
			catch
			{
				specialization = new Specialization(-1);
			}

			return specialization;
		}

		public List<Specialization> GetAllSpecialization()
		{
			var db = new ScooterlandDbContext();
			List<Specialization> specializations;
			try
			{
				specializations = db.Specializations.ToList();
			}
			catch
			{
				specializations = new List<Specialization>();
			}
			return specializations;
		}
	}
}