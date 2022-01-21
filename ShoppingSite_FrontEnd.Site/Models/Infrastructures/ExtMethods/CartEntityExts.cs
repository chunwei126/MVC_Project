using ShoppingSite_FrontEnd.Site.Models.EFModels;
using ShoppingSite_FrontEnd.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods
{
	public static class CartEntityExts
	{
		public static Cart ToEF(this CartEntity source)
		{
			var items = source.GetItems().Select(x => x.ToEF(source.Id)).ToList();

			return new Cart { Id = source.Id, MemberAccount = source.CustomerAccount, CartItems = items };
		}
	}
}