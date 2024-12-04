using System.ComponentModel.DataAnnotations;

namespace Scooterland.Shared.Models
{
	public class Customer
	{
		public int CustomerId { get; set; }
		[MaxLength(70, ErrorMessage = "Navnet må maksimalt være 70 tegn")]
		public string Name { get; set; }
		[MaxLength(100, ErrorMessage = "Email må maksimalt være 100 tegn")]
		public string Email { get; set; }
		[MaxLength(20, ErrorMessage = "Telefon nummer må maksimalt være 20 tegn lang")]
		public string Phonenumber { get; set; }
		[MaxLength(150, ErrorMessage = "Adressen må maksimalt være 150 tegn lang")]
		public string Address { get; set; }

		//Tom contructor til EF
		public Customer()
        {
            
        }
        public Customer(int id)
        {
			this.CustomerId = id;
        }
    }
}
