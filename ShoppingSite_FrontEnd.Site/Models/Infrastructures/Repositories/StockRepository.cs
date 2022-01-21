using ShoppingSite_FrontEnd.Site.Models.Core.Interfaces;
using ShoppingSite_FrontEnd.Site.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Infrastructures.Repositories
{
	public class StockRepository : IStockRepository
	{
		private readonly AppDbContext _db;

		public StockRepository(AppDbContext db)
			=> _db = db;

		/// <summary>
		/// qty不是新庫存值，而是要異動的差異數量；負數表示扣庫存，正數表示增加庫存
		/// </summary>
		/// <param name="info"></param>
		public void Update((int productId, int qty)[] info) // [(1, -2), (5, 1), (9, 2)]
		{
			if (info == null || info.Length == 0) return;

			int[] productIds = info.Select(x => x.productId).ToArray(); // [1, 5, 9]

			var products = _db.Products.Where(x => productIds.Contains(x.Id)).ToList();

			foreach (var product in products)
			{
				product.Stock += info.Single(x => x.productId == product.Id).qty;

				_db.SaveChanges();
			}
		}
	}
}