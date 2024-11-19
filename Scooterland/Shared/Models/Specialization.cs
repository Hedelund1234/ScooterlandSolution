using System.ComponentModel.DataAnnotations;

namespace Scooterland.Shared.Models
{
	public class Specialization
	{
		public int SpecializationId { get; set; }
		[MaxLength(30)]
		public string Brand { get; set; }
		List<Employee> Employees { get; set; }
	}
}
