using ShoppingSite_FrontEnd.Site.Models.Core.Interfaces;
using ShoppingSite_FrontEnd.Site.Models.Core.Services;
using ShoppingSite_FrontEnd.Site.Models.EFModels;
using ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods;
using ShoppingSite_FrontEnd.Site.Models.Infrastructures.Repositories;
using ShoppingSite_FrontEnd.Site.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingSite_FrontEnd.Site.Controllers
{
	public class PollsController : Controller
	{
		private PollService _PollsService;
		public PollsController()
		{
			var db = new AppDbContext();
			string connString = @"server=.\sql2019;user id=sa5;password=sa5;initial catalog=Project";
			IPollRepository repo = new PollRepository(connString, db);
			_PollsService = new PollService(repo);
		}

		public ActionResult Index()
		{
			var data = _PollsService.SearchVoteResults().Select(x => x.ToPollVM());
			return View(data);
		}

		public ActionResult Vote()
		{
			var data = _PollsService.SearchVoteResults().Select(x => x.ToPollVM());
			return View(data);
		}

		public ActionResult UpdateVote(int productId, int qty)
		{
			_PollsService.UpdateVote(productId, qty);

			return new EmptyResult();
		}

		public ActionResult ErrDevBar()
		{
			//TODO:建立X軸用以統計月份
			string[] ProductName = { "五香乖乖", "椰子乖乖" };
			ViewBag.MonthLabel = ProductName;
			List<ModelChartJs> Dev = new List<ModelChartJs>
						{
								new ModelChartJs
								{
										Dev="五香乖乖",
										ErrCount = new int[]
										{
											20
										}
								},
								new ModelChartJs
								{
										Dev="椰子乖乖",
										ErrCount = new int[]
										{
											50
										}
								}
						};
			return View(Dev);
		}
	}
}