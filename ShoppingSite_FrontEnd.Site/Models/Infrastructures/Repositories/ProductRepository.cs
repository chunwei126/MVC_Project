using ShoppingSite_FrontEnd.Site.Models.Core.Interfaces;
using ShoppingSite_FrontEnd.Site.Models.EFModels;
using ShoppingSite_FrontEnd.Site.Models.Entities;
using ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Infrastructures.Repositories
{
	public class ProductRepository : IProductRepository//讓IProductRepository繼承ProductRepository
	{
		private readonly AppDbContext _db;//讓_db只能在ProductRepository被呼叫(readonly唯讀(只能讀取不能更改資料))
		public ProductRepository(AppDbContext db)//只能傳輸來自資料庫的db
		{
			_db = db;
		}
		public IEnumerable<ProductEntity> Search(int? categoryId, string productName, bool? status)
		{
			IEnumerable<Product> query = _db.Products;//資料(query)是來自於資料庫(_db)的Product的資料表(Produts)

			if (categoryId.HasValue) query = query.Where(x => x.CategoryId == categoryId);//如果類別ID(categoryId)有值(HasValue)的話,就把他篩選(Where)出來

			if (!string.IsNullOrEmpty(productName)) query = query.Where(x => x.Name.Contains(productName));

			if (status.HasValue) query = query.Where(x => x.Status == status);//如果狀態(status)有值(HasValue//true+false)的話,就把他篩選(Where)出來

			query = query.OrderBy(x => x.Name);//用Name來排序

			return query.Select(x => x.ToProductEntity());//把EEmodel類型(query)的檔案轉換成Entity類型的檔案
		}
		
		
		public ProductEntity Load(int productId, bool? status)//Load加載
		{
			IEnumerable<Product> query = _db.Products//資料(query)是來自於資料庫(_db)的Product的資料表(Produts)

				.AsNoTracking()//不執行=>減少效能的損耗
				.Where(x => x.Id == productId);//篩選(Where)條件()是需要Products資料表中的Id需要跟Category資料表中的Id(CategoryId)一樣


			if (status.HasValue) query = query.Where(x => x.Status == status);//如果狀態(status)有值(HasValue//true+false)的話,就把他篩選(Where)出來

			Product product = query.SingleOrDefault();//單筆資料(SingleOrDefault)原因:因為前面的篩選條件是需要Products資料表中的Id需要跟Category資料表中的Id(CategoryId)一樣//所以產生出的結果只會有單筆資料

			return product == null ? null : product.ToProductEntity();
		}

		public HotProductEntity Load()
		{
			IEnumerable<Product> query = _db.HotProducts

			
			return
		}
	}
}