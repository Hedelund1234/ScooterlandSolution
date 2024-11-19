using System.ComponentModel.DataAnnotations;

namespace Scooterland.Shared.Models
{
	public class Customer
	{
		public int CustomerId { get; set; }
		[MaxLength(70)]
		public string Name { get; set; }
		[MaxLength(100)]
		public string Email { get; set; }
		[MaxLength(20)]
		public string Phonenumber { get; set; }
		[MaxLength(150)]
		public string Address { get; set; }
		public List<Sale> Sales { get; set; } = new List<Sale>();
	}
}
