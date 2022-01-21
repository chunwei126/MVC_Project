using ShoppingSite_FrontEnd.Site.Models.Core.Interfaces;
using ShoppingSite_FrontEnd.Site.Models.Core.Services;
using ShoppingSite_FrontEnd.Site.Models.EFModels;
using ShoppingSite_FrontEnd.Site.Models.Infrastructures.Repositories;
using ShoppingSite_FrontEnd.Site.Models.ValueObjects;
using ShoppingSite_FrontEnd.Site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingSite_FrontEnd.Site.Controllers
{
	public class CartController : Controller
	{
		private ICartService cartService;
		private IOrderService orderService;
		private IStockService stockService;

		public CartController()
		{
			AppDbContext db = new AppDbContext();
			ICartRepository cartRepo = new CartRepository(db);

			IProductRepository productRepo = new ProductRepository(db);

			ICustomerRepository customerRepo = new CustomerRepository(db);

			this.orderService = new OrderService(new OrderRepository(db));
			this.stockService = new StockService(new StockRepository(db));
			this.cartService = new CartService(cartRepo, productRepo, customerRepo);
		}

		private string CustomerAccount => User.Identity.Name;

		// GET: Cart/AddItem
		public ActionResult AddItem(int productId)
		{
			cartService.AddItem(CustomerAccount, productId, 1);

			return new EmptyResult();
		}

		public ActionResult Info()
		{
			var cart = cartService.Current(CustomerAccount);
			return View(cart);
		}

		public ActionResult UpdateItem(int productId, int Qty)
		{
			Qty = Qty <= 0 ? 0 : Qty;

			cartService.UpdateItem(CustomerAccount, productId, Qty);

			return new EmptyResult();
		}

		public ActionResult Checkout()
		{
			var cart = cartService.Current(this.CustomerAccount);
			if (cart.AllowCheckOut == false)
			{
				ViewBag.ErrorMessage = "購物車是空的，無法進行結帳";
			}

			return View();
		}

		[HttpPost]
		public ActionResult Checkout(CheckoutVM model, ShippingInfo info)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var cart = cartService.Current(this.CustomerAccount);

			if (cart.AllowCheckOut == false)
			{
				ModelState.AddModelError(string.Empty, "購物車是空的，無法進行結帳");
				return View(model);
			}

			var mediator = new CartMediator(this.cartService, orderService, stockService);

			cartService.Checkout(this.CustomerAccount, info);
			return View("CheckoutConfirm");
		}
	}
}