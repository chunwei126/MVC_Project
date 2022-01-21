using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Entities
{
	public class CartProductEntity
	{
		/// <summary>
		/// 供購物車使用的商品類別，僅包含必要資訊
		/// </summary>
		public int Id { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
	}
}