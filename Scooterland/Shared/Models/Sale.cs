using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scooterland.Shared.Models
{
	public class Sale
	{
		public int SaleId { get; set; }
		public int CustomerId { get; set; }
		public Customer? Customer { get; set; }
		public int? EmployeeId { get; set; }
		public Employee? Employee { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public int? SpecializationId { get; set; }
		public Specialization? Specialization { get; set; }
        public string? Comment { get; set; }


        //Tom contructor til EF
        public Sale()
        {
            
        }

        public Sale(int id)
        {
            this.SaleId = id;
        }
	}
}
