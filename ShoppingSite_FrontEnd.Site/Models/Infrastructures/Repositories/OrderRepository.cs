using ShoppingSite_FrontEnd.Site.Models.Core.Interfaces;
using ShoppingSite_FrontEnd.Site.Models.Dtos;
using ShoppingSite_FrontEnd.Site.Models.EFModels;
using ShoppingSite_FrontEnd.Site.Models.Entities;
using ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Infrastructures.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly AppDbContext _db;

		public OrderRepository(AppDbContext db)
			=> _db = db;

		public int Create(CreateOrderRequest request)
		{
			var order = new Order
			{
				MemberId = request.CustomerId,
				Total = request.Items.Sum(x => x.SubTotal),
				CreatedTime = DateTime.Now,
				Status = 1,
				Receiver = request.ShippingInfo.Receiver,
				Address = request.ShippingInfo.Address,
				CellPhone = request.ShippingInfo.CellPhone,
				OrderItems = request.Items.Select(x => x.ToEF()).ToList()
			};

			_db.Orders.Add(order);
			_db.SaveChanges();

			return order.Id;
		}

		public void RefundByCustomer(int orderId)
		{
			var order = _db.Orders.Find(orderId);
			if (order == null) throw new Exception("order not found");

			order.RequestRefund = true;
			order.RequestRefundTime = DateTime.Now;
			_db.SaveChanges();
		}

		public OrderEntity Load(int orderId)
		{
			return _db.Orders
				.AsNoTracking()
				.Include(x => x.OrderItems.Select(x2 => x2.Product))
				.Include(x => x.Member)
				.SingleOrDefault(x => x.Id == orderId)
				.ToEntity();
		}

		public IEnumerable<OrderEntity> Search(string customerAccount, DateTime? startTime = null, DateTime? endTime = null)
		{
			var query = _db.Orders
					.AsNoTracking()
					.Include(x => x.Member)
					.Include(x => x.OrderItems.Select(x2 => x2.Product))
					.Where(x => x.Member.Account == customerAccount);

			if (startTime.HasValue) query = query.Where(x => x.CreatedTime >= startTime);
			if (endTime.HasValue) query = query.Where(x => x.CreatedTime <= endTime);

			query = query.OrderByDescending(x => x.Id);

			return query.ToList()
									.Select(x => x.ToEntity()).ToList();
		}
	}
}