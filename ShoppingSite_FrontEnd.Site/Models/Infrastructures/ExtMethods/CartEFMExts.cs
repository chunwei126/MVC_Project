using ShoppingSite_FrontEnd.Site.Models.EFModels;
using ShoppingSite_FrontEnd.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods
{
	public static class CartEFMExts
	{
		public static CartEntity ToEntity(this Cart source)
		{
			var items = source.CartItems.Select(x => x.ToEntity()).ToList();

			return new CartEntity(source.Id, source.MemberAccount, items);
		}
	}
}