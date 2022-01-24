using ShoppingSite_FrontEnd.Site.Models.Core.Interfaces;
using ShoppingSite_FrontEnd.Site.Models.Core.Services;
using ShoppingSite_FrontEnd.Site.Models.EFModels;
using ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods;
using ShoppingSite_FrontEnd.Site.Models.Infrastructures.Repositories;
using ShoppingSite_FrontEnd.Site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingSite_FrontEnd.Site.Controllers
{
	public class HomeController : Controller
	{
		private ProductService _productService;
		public HomeController()
		{
			var db = new AppDbContext();
			IProductRepository repo = new ProductRepository(db);
			_productService = new ProductService(repo);
		}

		public ActionResult Index()
		{
			var latestProductsData = _productService.SearchLatestNewsProducts(null, null).Select(x => x.ToVM());

			var hotProductsData = _productService.SearchHotProducts().Select(x => x.ToHotProductVM());

			var data = new SliderVM();
			data.LatestProductsData = latestProductsData;
			data.HotProductsData = hotProductsData;

			return View(data);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

	}
}