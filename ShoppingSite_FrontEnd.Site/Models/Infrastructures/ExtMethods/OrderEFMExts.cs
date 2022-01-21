using ShoppingSite_FrontEnd.Site.Models.Core.Interfaces;
using ShoppingSite_FrontEnd.Site.Models.EFModels;
using ShoppingSite_FrontEnd.Site.Models.Entities;
using ShoppingSite_FrontEnd.Site.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods
{
	public static class OrderEFMExts
	{
		public static OrderEntity ToEntity(this Order source)
		{
			if (source == null) return null;

			List<OrderItemEntity> items = source.OrderItems.Select(x => x.ToEntity()).ToList();

			return new OrderEntity(
				source.Id,
				source.MemberId,
				items, source.CreatedTime,
				source.GetShippingInfo()
			)
			{
				CustomerAccount = source.Member.Account,
				Status = source.Status,
				RequestRefund = source.RequestRefund,
				RequestRefundTime = source.RequestRefundTime
			};
		}

		public static ShippingInfo GetShippingInfo(this Order source)
		{
			return new ShippingInfo
			{
				Receiver = source.Receiver,
				Address = source.Address,
				CellPhone = source.CellPhone
			};
		}
	}
}