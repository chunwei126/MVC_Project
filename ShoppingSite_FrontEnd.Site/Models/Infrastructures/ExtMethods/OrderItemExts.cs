using ShoppingSite_FrontEnd.Site.Models.EFModels;
using ShoppingSite_FrontEnd.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods
{
	public static class OrderItemExts
	{
		public static OrderItemEntity ToEntity(this OrderItem source)
			=> new OrderItemEntity(source.Id, source.Product.ToOrderProductEntity(), source.Qty);
	}
}