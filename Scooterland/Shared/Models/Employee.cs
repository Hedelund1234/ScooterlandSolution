using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scooterland.Shared.Models
{
	public class Employee
	{
		public int EmployeeId { get; set; }
		[MaxLength(70)]
		public string Name { get; set; }
		[MaxLength(30)]
		public string Role { get; set; }
		public List<Specialization> Specializations { get; set; } = new List<Specialization>();
		//public List<Sale> Sale { get; set; } = new List<Sale>();

		//Tom contructor til EF
		public Employee()
        {
            
        }

		public Employee(int id)
		{
			this.EmployeeId = id;
		}
	}
}
