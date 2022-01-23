using ShoppingSite_FrontEnd.Site.Models.Core.Interfaces;
using ShoppingSite_FrontEnd.Site.Models.Core.Services;
using ShoppingSite_FrontEnd.Site.Models.EFModels;
using ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods;
using ShoppingSite_FrontEnd.Site.Models.Infrastructures.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace ShoppingSite_FrontEnd.Site.Controllers
{
	public class ProductController : Controller
	{
		private ProductService _productService;//命名
		public ProductController()//建構子(Service不會直接呼叫資料庫,需要透過媒介(IProductRepository))
		{
			var db = new AppDbContext();//抽出資料庫(AppDbContext)->db
			IProductRepository repo = new ProductRepository(db);//db->ProductRepository->(繼承)IProductRepository(媒介)
			_productService = new ProductService(repo);//IProductReprository(媒介)->ProductService
		}

		public ActionResult Index(int pageNumber = 1, int pageSize = 3)
		{
			var data = _productService.SearchProducts(null, null).Select(x => x.ToVM());
			var userPagedList = data.OrderBy(x => x.Id).ToPagedList(pageNumber, pageSize);
			return View(userPagedList);
		}

		public ActionResult Cookies()
		{
			var data = _productService.SearchProducts(4, null).Select(x => x.ToVM());
			return View(data);
		}

		public ActionResult Candies()
		{
			var data = _productService.SearchProducts(3, null).Select(x => x.ToVM());
			return View(data);
		}

		public ActionResult InstantNoodles()
		{
			var data = _productService.SearchProducts(5, null).Select(x => x.ToVM());
			return View(data);
		}

		public ActionResult SoftDrinks()
		{
			var data = _productService.SearchProducts(6, null).Select(x => x.ToVM());
			return View(data);
		}

		public ActionResult HardDrinks()
		{
			var data = _productService.SearchProducts(8, null).Select(x => x.ToVM());
			return View(data);
		}
	}
}