using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scooterland.Shared.Models
{
	public class Product
	{
		public int ProductId { get; set; }
		[MaxLength(70)]
		public string Name { get; set; }
		[MaxLength(30)]
		public string Type { get; set; }
		public decimal Price { get; set; }
		public List<SalesLineItem> SalesLineItems { get; set; } = new List<SalesLineItem>();
	}
}
