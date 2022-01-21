using ShoppingSite_FrontEnd.Site.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Entities
{
	/// <summary>
	/// 這是 Aggregate root
	/// </summary>
	public class CartEntity
	{
		// New一個購物車用的
		public CartEntity(int id, string customerAccount)
		{
			this.Id = id;
			this.CustomerAccount = customerAccount;
			Items = new List<CartItemEntity>();
		}

		// Load用
		public CartEntity(int id, string customerAccount, List<CartItemEntity> items)
		{
			this.Id = id;
			this.CustomerAccount = customerAccount;
			Items = items;
		}

		public int Id { get; set; }

		private string _CustomerAccount;

		public string CustomerAccount
		{
			get => _CustomerAccount;
			set => _CustomerAccount = string.IsNullOrEmpty(value) == false
				? value
				: throw new Exception("CustomerAccount 不能是空值");
		}

		private List<CartItemEntity> Items;
		public int Total => Items == null || Items.Count == 0 ? 0 : Items.Sum(x => x.SubTotal);
		public bool AllowCheckOut => Items != null && Items.Count > 0;

		public ShippingInfo ShippingInfo { get; set; }

		// AddItem 要避免直接存取repo，所以參數不寫 productId 而是寫 CartProductEntity product
		public void AddItem(CartProductEntity product, int qty)
		{
			if (product == null) throw new ArgumentNullException(nameof(product));
			if (qty <= 0) throw new ArgumentOutOfRangeException(nameof(qty));

			var item = Items.SingleOrDefault(x => x.Product.Id == product.Id);

			// 如果購物車裡面沒有那筆項目，就新增一筆
			if (item == null)
			{
				var cartItem = new CartItemEntity(product, qty);
				this.Items.Add(cartItem);
			}
			// 如果購物車裡有那筆項目，就直接對數量+1
			else
			{
				item.Qty += qty;
			}
		}

		public void RemoveItem(int productId)
		{
			var item = Items.SingleOrDefault(x => x.Product.Id == productId);
			if (item == null) return;

			Items.Remove(item);
		}

		public void UpdateQty(int productId, int newQty)
		{
			if (newQty <= 0)
			{
				RemoveItem(productId);
				return;
			}

			var item = Items.SingleOrDefault(x => x.Product.Id == productId);
			if (item == null) return;

			item.Qty = newQty;
		}

		// 因為Items被設為Private的關係，所以要透過此Method來傳出Items;
		public IEnumerable<CartItemEntity> GetItems()
			=> this.Items;
	}
}