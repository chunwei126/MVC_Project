using ShoppingSite_FrontEnd.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSite_FrontEnd.Site.Models.Core.Interfaces
{
	public interface IProductRepository
	{
		/// <summary>
		/// 篩選商品
		/// </summary>
		/// <param name="categoryId"></param>
		/// <param name="productName"></param>
		/// <param name="status"></param>//狀態
		/// <returns></returns>
		IEnumerable<ProductEntity> Search(int? categoryId, string productName, bool? status);//IEnumerable櫃子
		/// <summary>
		/// 傳回一筆商品
		/// </summary>
		/// <param name="productId"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		ProductEntity Load(int productId, bool? status);

		IEnumerable<HotProductEntity> Search();
	}
}
