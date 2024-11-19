using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scooterland.Shared.Models
{
	public class Customer
	{
		public int CustomerId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phonenumber { get; set; }
		public string Address { get; set; }
	}
}
