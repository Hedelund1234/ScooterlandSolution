using Scooterland.Server.DataAccess;
using Scooterland.Server.Validators;
using Scooterland.Shared.Models;

namespace Scooterland.Server.Repositories.SpecializationRepository
{
	public class SpecializationRepositoryEF : ISpecializationRepository
	{
		public void AddSpecialization(Specialization specialization)
		{
            var validation = new MyValidator();
            bool isValid = validation.SpecializationCreateValidation(specialization);
            if (isValid)
			{
				try
				{
					var db = new ScooterlandDbContext();
					db.Specializations.Add(specialization);
					db.SaveChanges();
				}
				catch (Exception ex)
				{
                    
				}
			}
		}

		public bool DeleteSpecialization(int id)
		{
			try
			{
				int changed = 0;
				var db = new ScooterlandDbContext();
				Specialization specialization;
				specialization = db.Specializations.Where(x => x.SpecializationId == id).FirstOrDefault();
				if (id == specialization.SpecializationId)
				{
					db.Specializations.Remove(specialization);
					changed = db.SaveChanges();
				}
				if (changed > 0)
				{
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				
				return false;
			}
		}


		public bool UpdateSpecialization(Specialization specialization)
		{
            var validation = new MyValidator();
            bool isValid = validation.SpecializationUpdateValidation(specialization);
            if (isValid)
			{
                try
                {
                    var db = new ScooterlandDbContext();
                    Specialization foundSpecialization = db.Specializations.Where(x => x.SpecializationId == specialization.SpecializationId).FirstOrDefault();


                    if (specialization == null)
                    {
                        return false;
                    }

                    if (specialization.Brand == foundSpecialization.Brand)
                    {
                        return true;
                    }

                    foundSpecialization.Brand = specialization.Brand;
                    int changed = db.SaveChanges();

                    if (changed > 0)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
			return false;
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