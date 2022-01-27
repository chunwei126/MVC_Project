using ShoppingSite_FrontEnd.Site.Models.Core.Interfaces;
using ShoppingSite_FrontEnd.Site.Models.Dtos;
using ShoppingSite_FrontEnd.Site.Models.Entities;
using ShoppingSite_FrontEnd.Site.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Core.Services
{
	public class CartService : ICartService
	{
		public event Action<ICartService, string> RequestCheckout;

		private readonly ICartRepository _repository;
		private readonly IProductRepository _productRepo;
		private readonly ICustomerRepository _customerRepo;

		public CartService(ICartRepository repository,
					IProductRepository productRepo,
					ICustomerRepository customerRepo)
		{
			_repository = repository;
			_productRepo = productRepo;
			_customerRepo = customerRepo;
		}

		private ShippingInfo shippingInfo;

		public void Checkout(string customerAccount, ShippingInfo shippingInfo)
		{
			if (string.IsNullOrEmpty(customerAccount)) throw new ArgumentNullException(nameof(customerAccount));

			if (shippingInfo == null) throw new Exception("ShippingInfo not allow null");

			this.shippingInfo = shippingInfo; // 先暫存，ToCreateOrderRequest會用到
			OnRequestCheckout(customerAccount); // 觸發 RequestCheckout 事件
		}

		protected virtual void OnRequestCheckout(string customerAccount)
		{
			if (RequestCheckout != null)
			{
				RequestCheckout(this, customerAccount);
			}
		}

		public CartEntity Current(string customerAccount)
		{
			if (_repository.IsExists(customerAccount))
			{
				return _repository.Load(customerAccount);
			}
			else
			{
				return _repository.CreateNewCart(customerAccount);
			}
		}

		public void AddItem(string customerAccount, int productId, int qty = 1)
		{
			var cart = Current(customerAccount); // 判斷購物車是否存在

			var product = _productRepo.Load(productId, true); // 撈該商品的資訊

			var cartProd = new CartProductEntity { Id = productId, Name = product.Name, Price = product.Price };

			// 呼叫 CartEntity裡面的AddItem來執行，讓版面看起來整潔
			cart.AddItem(cartProd, qty);

			// 這裡的Save是我們自己寫的method
			_repository.Save(cart);
		}

		public void UpdateItem(string customerAccount, int productId, int newQty)
		{
			var cart = Current(customerAccount);
			cart.UpdateQty(productId, newQty);
			_repository.Save(cart);
		}

		public void RemoveItem(string customerAccount, int productId)
		{
			var cart = Current(customerAccount);
			cart.RemoveItem(productId);
			_repository.Save(cart);
		}

		public void EmptyCart(string customerAccount)
		{
			_repository.EmptyCart(customerAccount);
		}

		public CreateOrderRequest ToCreateOrderRequest(CartEntity cart)
		{
			List<CreateOrderItem> items = cart.GetItems()
				.Select(x =>
									new CreateOrderItem
									{
										ProductId = x.Product.Id,
										ProductName = x.Product.Name,
										Price = x.Product.Price,	
										Qty = x.Qty
									})
				.ToList();

			return new CreateOrderRequest
			{
				CustomerId = _customerRepo.GetCustomerId(cart.CustomerAccount),
				Items = items,
				ShippingInfo = this.shippingInfo
			};
		}

		public DeductStockInfo[] GetDeductStockInfo(CartEntity cart)
		{
			return cart.GetItems()
				.Select(x => new DeductStockInfo { ProductId = x.Product.Id, Qty = x.Qty })
				.ToArray();
		}
	}
}