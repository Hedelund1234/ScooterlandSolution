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
		Customer Customer { get; set; }
		public int EmployeeId { get; set; }
		Employee Employee { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public decimal Payment { get; set; }
		List<SalesLineItem> SalesLineItem { get; set; }
		

	}
}
