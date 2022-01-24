using ShoppingSite_FrontEnd.Site.Models.Core.Interfaces;
using ShoppingSite_FrontEnd.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Core.Services
{
	public class ProductService
	{
		private readonly IProductRepository _repository;//讓_repository只能在ProductService用(readonly唯讀(只能讀取不能更改資料))

		public ProductService(IProductRepository repository)//只能傳輸來自IProductRepository的repository
		{
			_repository = repository;
		}

		public IEnumerable<ProductEntity> SearchProducts(int? categoryId, string productName)//用SearchProducts這個動作來呼叫_repository(IProductRepository)
		=>
				_repository.Search(categoryId, productName, true);//用_repository(IProductRepository)來執行Search

		public ProductEntity LoadProduct(int productId)//用LoadProduct這個動作來呼叫_repository(IProductRepository)
		=>
				_repository.Load(productId, true);//用_repository(IProductRepository)來執行Load

		//public IEnumerable<ProductEntity> SearchLatestProducts()

		public IEnumerable<HotProductEntity> SearchHotProducts()
		{
			return _repository.Search();
		}

		public IEnumerable<ProductEntity> SearchLatestNewsProducts(int? categoryId, string productName)//用SearchProducts這個動作來呼叫_repository(IProductRepository)
								=>
										_repository.SearchLatestNews(categoryId, productName, true);//用_repository(IProductRepository)來執行Search
	}
}