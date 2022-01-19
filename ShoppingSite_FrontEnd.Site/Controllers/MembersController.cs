using ShoppingSite_FrontEnd.Site.Models.Core.Interfaces;
using ShoppingSite_FrontEnd.Site.Models.Core.Services;
using ShoppingSite_FrontEnd.Site.Models.Dtos;
using ShoppingSite_FrontEnd.Site.Models.EFModels;
using ShoppingSite_FrontEnd.Site.Models.Infrastructures.Repositories;
using ShoppingSite_FrontEnd.Site.Models.UseCases;
using ShoppingSite_FrontEnd.Site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingSite_FrontEnd.Site.Controllers
{
	public class MembersController : Controller
	{
		private IMemberService _memberService;

		public MembersController()
		{
			var db = new AppDbContext();
			IMemberRepository repo = new MemberRepository(db);
			this._memberService = new MemberService(repo);
		}

		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Register(RegisterVM registerVM)
		{
			// 驗證欄位
			if (!ModelState.IsValid)
			{
				return View(registerVM);
			}

			// 呼叫 Command 來執行發信動作
			MemberCommand memberCommand = new MemberCommand(_memberService);
			RegisterResponse registerResponse = memberCommand.SendMail(registerVM);

			if (registerResponse.IsSuccess)
			{
				return View("RegisterConfirm");
			}
			else
			{
				ModelState.AddModelError(string.Empty, registerResponse.ErrorMessage);
				return View(registerVM);
			}
		}


		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Login(LoginVM model)
		{
			LoginResponse response = service.Login(model.Account, model.Password);
			if (response.IsSuccess)
			{
				// 記住登入成功的會員
				var rememberMe = false;

				string returnUrl = ProcessLogin(model.Account, rememberMe, out HttpCookie cookie);

				Response.Cookies.Add(cookie);

				return Redirect(returnUrl);
			}

			ModelState.AddModelError(string.Empty, response.ErrorMessage);

			return this.View(model);
		}
	}
}