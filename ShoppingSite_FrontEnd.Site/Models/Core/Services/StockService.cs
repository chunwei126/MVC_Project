using ShoppingSite_FrontEnd.Site.Models.Core.Interfaces;
using ShoppingSite_FrontEnd.Site.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Core.Services
{
	public class StockService : IStockService
	{
		private readonly IStockRepository _repository;

		public StockService(IStockRepository repository)
		{
			_repository = repository;
		}

		public void Deduct(DeductStockInfo[] info)
		{
			var tuple = info
				.Select(x => (x.ProductId, x.Qty * -1))
				.ToArray();

			_repository.Update(tuple);
		}

		public void Revise(ReviseStockInfo[] info)
		{
			var tuple = info
				.Select(x => (x.ProductId, x.Qty))
				.ToArray();

			_repository.Update(tuple);
		}
	}
}