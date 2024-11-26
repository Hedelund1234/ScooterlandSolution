using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scooterland.Server.Repositories.ProductRepository;
using Scooterland.Server.Repositories.SalesLineItemRepository;
using Scooterland.Shared.Models;
using System.Net;

namespace Scooterland.Server.Controllers
{
	[Route("api/saleslineitemapi")]
	[ApiController]
	public class SalesLineItemController : ControllerBase
	{
		private readonly ISalesLineItemRepository Repository = new SalesLineItemRepositoryEF();


		public SalesLineItemController(ISalesLineItemRepository salesLineItemRepository)
		{
			if (Repository == null && salesLineItemRepository != null)
			{
				Repository = salesLineItemRepository;
				Console.WriteLine("Repository initialized");
			}
		}


		[HttpGet]
		public IEnumerable<SalesLineItem> GetAllSalesLineItem()
		{
			return Repository.GetAllSalesLineItem();
		}

		[HttpDelete("{id:int}")]
		public StatusCodeResult DeleteSalesLineItem(int id)
		{
			Console.WriteLine("Server: Delete salesLineItem called: id = " + id);

			bool deleted = Repository.DeleteSalesLineItem(id);
			if (deleted)
			{
				Console.WriteLine("Server: SalesLineItem deleted succces");
				int code = (int)HttpStatusCode.OK;
				return new StatusCodeResult(code);
			}
			else
			{
				Console.WriteLine("Server: SalesLineItem deleted fail - not found");
				int code = (int)HttpStatusCode.NotFound;
				return new StatusCodeResult(code);
			}
		}

		[HttpPost]
		public void AddSalesLineItem(SalesLineItem salesLineItem)
		{
			Console.WriteLine("Add salesLineItem called: " + salesLineItem.ToString());
			Repository.AddSalesLineItem(salesLineItem);
		}



		[HttpGet("{id:int}")]
		public SalesLineItem FindSalesLineItem(int id)
		{
			var result = Repository.FindSalesLineItem(id);
			return result;
		}

		[HttpPatch]
		public StatusCodeResult UpdateSalesLineItem(SalesLineItem salesLineItem)
		{
			bool updated = Repository.UpdateSalesLineItem(salesLineItem);
			if (updated)
			{
				Console.WriteLine("Server: SalesLineItem updated succces");
				int code = (int)HttpStatusCode.OK;
				return new StatusCodeResult(code);
			}
			else
			{
				Console.WriteLine("Server: SalesLineItem updated fail - something went wrong");
				int code = (int)HttpStatusCode.NotFound;
				return new StatusCodeResult(code);
			}
		}
	}
}
