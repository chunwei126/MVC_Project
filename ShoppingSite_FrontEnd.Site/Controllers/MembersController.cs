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
using System.Web.Security;

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
		public ActionResult Login(LoginVM loginVM)
		{
			LoginResponse loginResponse = _memberService.Login(loginVM.Account, loginVM.Password);
			
			// 如果登入成功，設定Cookie並轉址
			if (loginResponse.IsSuccess)
			{
				string returnUrl = ProcessLogin(loginVM.Account, out HttpCookie cookie);

				Response.Cookies.Add(cookie);

				return Redirect(returnUrl);
			}

			// 如果登入失敗，傳回錯誤訊息
			ModelState.AddModelError(string.Empty, loginResponse.ErrorMessage);
			return this.View(loginVM);
		}

		// 設定Cookie，給Login呼叫用
		private string ProcessLogin(string account, out HttpCookie cookie)
		{
			string roles = String.Empty;
			bool rememberMe = false;

			// 建立一張認證票
			FormsAuthenticationTicket ticket =
				new FormsAuthenticationTicket(
					1,          // 版本別, 沒特別用處
					account,
					DateTime.Now,   // 發行日
					DateTime.Now.AddDays(2), // 到期日
					rememberMe,     // 是否續存
					roles,          // userdata
					"/" // cookie位置
				);

			// 將它加密
			string value = FormsAuthentication.Encrypt(ticket);

			// 存入cookie
			cookie = new HttpCookie(FormsAuthentication.FormsCookieName, value);

			// 取得return url
			string url = FormsAuthentication.GetRedirectUrl(account, true);
			return url;
		}

		[Authorize]
		public ActionResult Logout()
		{
			Session.Abandon();
			FormsAuthentication.SignOut();
			return Redirect("/Members/Login");
		}
	}
}