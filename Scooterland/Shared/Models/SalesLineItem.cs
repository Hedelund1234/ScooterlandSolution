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
		public Sale? Sale { get; set; }
		public int ProductId { get; set; }
		public Product? Product { get; set; }
		public int Quantity { get; set; }
		public int Discount { get; set; }
		//Tom contructor til EF
		public SalesLineItem()
		{

		}
		public SalesLineItem(int id)
		{
			this.SalesLineItemId = id;
		}
	}
}
