using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scooterland.Shared.Models
{
	public class Product
	{
		public int ProductId { get; set; }
		[MaxLength(70)]
		[StringLength(70, ErrorMessage ="Navnet må maksimalt være 70 anslag lang!")]
		public string Name { get; set; }
		[MaxLength(30)]
		[StringLength(30, ErrorMessage ="Type må maksimalt være 30 anslag lang!")]
		public string Type { get; set; }
		[Range(minimum:0,maximum:System.Int32.MaxValue, ErrorMessage = "Prisen skal være positiv!")]
		public decimal Price { get; set; }
		public List<SalesLineItem> SalesLineItems { get; set; } = new List<SalesLineItem>();

		//Tom contructor til EF
		public Product()
        {
            
        }
    }
}
