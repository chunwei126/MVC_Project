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

		public ActionResult Index()
		{
			var data = _productService.SearchProducts(null, null).Select(x => x.ToVM());//SearchProducts(全部資料)Select(挑選)ToVM(讓挑選出來的資料(EFMODEL)轉換成(ToViewModel)//ViewModel為網頁個別產品所要列出的商品公式的群組
			return View(data);//輸入資料(data)呈現畫面
		}
	}
}