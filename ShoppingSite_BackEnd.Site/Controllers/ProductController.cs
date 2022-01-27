using ShoppingSite_BackEnd.Site.Models.Core.Interfaces;
using ShoppingSite_BackEnd.Site.Models.Core.Services;
using ShoppingSite_BackEnd.Site.Models.Infrastructures.ExtMethods;
using ShoppingSite_BackEnd.Site.Models.Infrastructures.Repositories;
using ShoppingSite_BackEnd.Site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingSite_BackEnd.Site.Controllers
{
	public class ProductController : Controller
	{
		private ProductService service;
		private IProductRepository repository;

		public ProductController()
		{
			service = new ProductService();
			repository = new ProductRepository();
		}

		public ActionResult Index(string name, string description)
		{
			var data = repository
					.Search(name, description)
					.Select(x => x.ToProductIndexVM())
					.OrderBy(x1 => x1.Id);

			ViewBag.search_name = name;
			ViewBag.search_description = description;

			return View(data);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(ProductVM model, HttpPostedFileBase file)
		{
			// 檢查有沒有上傳檔案(必填)
			if (file == null || file.FileName == null || file.ContentLength == 0)
			{
				ModelState.AddModelError("FileName", "檔案必填");
				return View(model);
			}

			// 將檔案存檔，並得知實際儲存的檔名
			string path = Server.MapPath("~/Files/");
			string newFileName = SaveFile(file, path);

			// 將新檔名存到model中
			model.ProductImage = newFileName;

			// 新增紀錄
			service.Create(model.ToProductRequest());

			// redirect to index
			return RedirectToAction("Index");
		}

		public ActionResult Edit(int id)
		{
			var entity = repository.Load(id);

			return View(entity.ToEditProductVM());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(ProductEditVM model, HttpPostedFileBase file, string btnDelete)
		{
			string origFileName = repository.Load(model.Id).ProductImage;

			if (string.IsNullOrEmpty(btnDelete) == false) return Delete(model, origFileName);

			if (ModelState.IsValid == false) return View(model);

			// 如果有上傳檔案就存檔取得新檔名，且加到model中
			string path = Server.MapPath("~/Files/");
			string newFileName = TrySaveFile(path, file);

			model.ProductImage = string.IsNullOrEmpty(newFileName) ? origFileName : newFileName;

			// 更新紀錄
			service.Update(model.ToProductRequest());

			// 如果有上傳檔案，就刪舊檔
			TryDeleteFile(path, origFileName);

			return RedirectToAction("Index");
		}

		private void TryDeleteFile(string path, string fileName)
		{
			string fullName = System.IO.Path.Combine(path, fileName);
			if (System.IO.File.Exists(fullName) == false) return;

			System.IO.File.Delete(fullName);
		}

		private ActionResult Delete(ProductEditVM model, string fileName)
		{
			try
			{
				this.service.Delete(model.Id);
				string path = Server.MapPath("~/Files/");
				TryDeleteFile(path, fileName);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
				return this.View("Edit", model);
			}
		}

		/// <summary>
		/// 如果有上傳檔案就存檔取得新檔名
		/// </summary>
		/// <param name="file"></param>
		/// <param name="path"></param>
		/// <returns></returns>
		private string TrySaveFile(string path, HttpPostedFileBase file)
		{
			if (file == null || file.FileName == null || file.ContentLength == 0) return String.Empty;

			string ext = System.IO.Path.GetExtension(file.FileName);
			string targetFileName = Guid.NewGuid().ToString("N") + ext;
			string fullName = System.IO.Path.Combine(path, targetFileName);

			file.SaveAs(fullName);

			return targetFileName;
		}


		/// <summary>
		/// 將上傳檔案存檔，並傳回儲存的新檔案名稱
		/// </summary>
		/// <param name="file"></param>
		/// <param name="path"></param>
		/// <returns></returns>
		private string SaveFile(HttpPostedFileBase file, string path)
		{
			// 取得上傳的副檔名
			string ext = System.IO.Path.GetExtension(file.FileName);

			// 為它建立一個唯一的新檔名
			string targetFileName = Guid.NewGuid().ToString("N") + ext;

			string fullName = System.IO.Path.Combine(path, targetFileName);

			file.SaveAs(fullName);

			// 給前台用
			string frontPath = @"C:\Users\bruce\OneDrive\桌面\帥哥美女購物網\ShoppingSite_FrontEnd.Site\Assest";
			string frontFullName = System.IO.Path.Combine(frontPath, targetFileName);
			file.SaveAs(frontFullName);

			return targetFileName;
		}
	}
}