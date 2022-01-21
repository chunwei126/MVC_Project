using ShoppingSite_FrontEnd.Site.Models.EFModels;
using ShoppingSite_FrontEnd.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods
{
	public static class CartItemEFMExts
	{
		public static CartItemEntity ToEntity(this CartItem source)
		{
			CartProductEntity prod = source.Product.ToCartProduct();
			return new CartItemEntity(prod, source.Qty) { Id = source.Id };
		}
	}
}