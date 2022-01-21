using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Entities
{
	public class CartItemEntity
	{
		public CartItemEntity(CartProductEntity product, int qty)
		{
			Product = product;
			Qty = qty;
		}

		public int Id { get; set; }

		private CartProductEntity _Product;
		public CartProductEntity Product
		{
			get => _Product;
			set => _Product = value != null ? value : throw new Exception("Product不能是null");
		}

		private int _Qty;
		public int Qty
		{
			get => _Qty;
			set => _Qty = value > 0 ? value : throw new Exception("Qty必須是正數");
		}

		public int SubTotal => Product.Price * Qty;
	}
}