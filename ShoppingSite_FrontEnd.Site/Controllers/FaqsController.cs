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
	public class FaqsController : Controller
	{
		private AppDbContext db = new AppDbContext();

		public ActionResult Index()
		{
			return View(db.Faqs.ToList());
		}
	}
}
