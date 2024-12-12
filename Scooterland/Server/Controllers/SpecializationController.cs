using Microsoft.AspNetCore.Mvc;
using Scooterland.Server.Repositories.SpecializationRepository;
using Scooterland.Shared.Models;
using System.Net;


namespace Scooterland.Server.Controllers
{
	[ApiController]
	[Route("api/specializationapi")]
	public class SpecializationController : ControllerBase
	{
		private readonly ISpecializationRepository Repository = new SpecializationRepositoryEF();

		public SpecializationController(ISpecializationRepository specializationRepository)
		{
			if (Repository == null && specializationRepository != null)
			{
				Repository = specializationRepository;
				Console.WriteLine("Repository initialized");
			}
		}

		[HttpGet]
		public IEnumerable<Specialization> GetAllSpecializations()
		{
			return Repository.GetAllSpecialization();
		}

		[HttpDelete("{id:int}")]
		public StatusCodeResult DeleteSpecialization(int id)
		{
			Console.WriteLine("Server: Delete specialization called: id = " + id);

			bool deleted = Repository.DeleteSpecialization(id);
			if (deleted)
			{
				Console.WriteLine("Server: Specialization deleted success");
				int code = (int)HttpStatusCode.OK;
				return new StatusCodeResult(code);
			}
			else
			{
				Console.WriteLine("Server: Specialization deleted fail - not found");
				int code = (int)HttpStatusCode.NotFound;
				return new StatusCodeResult(code);
			}
		}

		[HttpPost]
		public void AddSpecialization(Specialization specialization)
		{
			Console.WriteLine("Add specialization called: " + specialization.ToString());
			Repository.AddSpecialization(specialization);
        }

		[HttpGet("{id:int}")]
		public Specialization FindSpecialization(int id)
		{
			var result = Repository.FindSpecialization(id);
			return result;
		}

		[HttpPatch]
		public StatusCodeResult UpdateSpecialization(Specialization specialization)
		{
			bool updated = Repository.UpdateSpecialization(specialization);
			if (updated)
			{
				Console.WriteLine("Server: Specialization updated success");
				int code = (int)HttpStatusCode.OK;
				return new StatusCodeResult(code);
			}
			else
			{
				Console.WriteLine("Server: Specialization updated fail - something went wrong");
				int code = (int)HttpStatusCode.NotFound;
				return new StatusCodeResult(code);
			}
		}
	}
}
