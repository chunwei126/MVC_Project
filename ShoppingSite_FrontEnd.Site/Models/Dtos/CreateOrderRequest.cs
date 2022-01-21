using ShoppingSite_FrontEnd.Site.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Dtos
{
	public class CreateOrderRequest
	{
		public int CustomerId { get; set; }

		public List<CreateOrderItem> Items { get; set; }

		public int Total => Items.Sum(x => x.SubTotal);

		public ShippingInfo ShippingInfo { get; set; }
	}
}