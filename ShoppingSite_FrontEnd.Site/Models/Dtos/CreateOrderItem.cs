using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Dtos
{
	public class CreateOrderItem
	{
		public int ProductId { get; set; }

		public string ProductName { get; set; }

		public int Price { get; set; }

		public int Qty { get; set; }

		public int SubTotal => Price * Qty;
	}
}