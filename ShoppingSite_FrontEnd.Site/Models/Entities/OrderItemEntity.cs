using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Entities
{
	public class OrderItemEntity
	{
		public OrderItemEntity(int id, OrderProductEntity product, int qty)
		{
			Id = id;
			Product = product;
			Qty = qty;
		}

		public int Id { get; set; }

		private OrderProductEntity _Product;

		public OrderProductEntity Product
		{
			get => _Product;
			set => _Product = value != null ? value : throw new Exception("Product不能是null");
		}

		private int _Qty;

		public int Qty
		{
			get => _Qty;
			set => _Qty = value > 0 ? value : throw new Exception("Qty必須大於零");
		}

		public int SubTotal => Product.Price * Qty;
	}
}