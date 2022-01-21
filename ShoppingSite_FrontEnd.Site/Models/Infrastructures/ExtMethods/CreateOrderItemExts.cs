using ShoppingSite_FrontEnd.Site.Models.Dtos;
using ShoppingSite_FrontEnd.Site.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods
{
	public static class CreateOrderItemExts
	{
		public static OrderItem ToEF(this CreateOrderItem source)
		{
			return new OrderItem
			{
				ProductId = source.ProductId,
				ProductName = source.ProductName,
				Price = source.Price,
				Qty = source.Qty,
				SubTotal = source.SubTotal
			};
		}
	}
}