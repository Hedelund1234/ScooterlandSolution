using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scooterland.Shared.Models
{
	public class SalesLineItem
	{
		public int SalesLineItemId { get; set; }
		public int SaleId { get; set; }
		Sale Sale { get; set; }
		public int ProductId { get; set; }
		Product Product { get; set; }
		public int Quantity { get; set; }
		public decimal Discount { get; set; }
	}
}
