using ShoppingSite_FrontEnd.Site.Models.EFModels;
using ShoppingSite_FrontEnd.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods
{
	public static class CartItemEntityExts
	{
		public static CartItem ToEF(this CartItemEntity source, int cartId)
		{
			return new CartItem { Id = source.Id, CartId = cartId, ProductId = source.Product.Id, Qty = source.Qty };
		}
	}
}