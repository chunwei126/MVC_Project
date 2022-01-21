using ShoppingSite_FrontEnd.Site.Models.Core.Interfaces;
using ShoppingSite_FrontEnd.Site.Models.EFModels;
using ShoppingSite_FrontEnd.Site.Models.Entities;
using ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Infrastructures.Repositories
{
	public class CartRepository : ICartRepository
	{
		private readonly AppDbContext _db;

		public CartRepository(AppDbContext db)
			=> _db = db;

		public bool IsExists(string customerAccount)
			=> _db.Carts.SingleOrDefault(x => x.MemberAccount == customerAccount) != null;

		public CartEntity CreateNewCart(string customerAccount)
		{
			var cart = new Cart { MemberAccount = customerAccount };
			_db.Carts.Add(cart);
			_db.SaveChanges();

			return Load(customerAccount);
		}

		public CartEntity Load(string customerAccount) // 應該是找尋目前屬於customerAccount的購物車
		=> _db.Carts
				.AsNoTracking()
				.Include(cart => cart.CartItems.Select(CartItem => CartItem.Product))
				.Single(cart => cart.MemberAccount == customerAccount).ToEntity();

		public void EmptyCart(string customerAccount)
		{
			var cart = _db.Carts.SingleOrDefault(x => x.MemberAccount == customerAccount);
			if (cart == null) return;
			_db.Carts.Remove(cart);
			_db.SaveChanges();
		}

		public void Save(CartEntity cart)
		{
			var cartEF = cart.ToEF();

			var efInDb = _db.Carts
					.Include(x => x.CartItems)
					.Single(x => x.Id == cart.Id);

			var efItemsInDb = efInDb.CartItems.ToList();

			var deletedProducts = efItemsInDb.Select(x => x.ProductId)
					.Except(cartEF.CartItems.Select(x => x.ProductId))
					.ToList();

			foreach (var productId in deletedProducts)
			{
				var delItem = efInDb.CartItems.Single(x => x.ProductId == productId);

				_db.Entry(delItem).State = EntityState.Deleted;
			}

			foreach (var item in cartEF.CartItems)
			{
				if (item.Id == 0)
				{
					efInDb.CartItems.Add(item);
				}
				else
				{
					efInDb.CartItems.Single(x => x.Id == item.Id).Qty = item.Qty;
				}
			}

			_db.SaveChanges();
		}
	}
}