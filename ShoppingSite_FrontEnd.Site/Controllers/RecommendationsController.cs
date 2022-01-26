using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingSite_FrontEnd.Site.Models.EFModels;

namespace ShoppingSite_FrontEnd.Site.Controllers
{
	public class RecommendationsController : Controller
	{
		private AppDbContext db = new AppDbContext();

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,ProductName,Description,ProductImage,Name,Email,CreateTime")] Recommendation recommendation)
		{
			if (ModelState.IsValid)
			{
				db.Recommendations.Add(recommendation);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(recommendation);
		}
	}
}
