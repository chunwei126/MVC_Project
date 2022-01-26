using Dapper;
using ShoppingSite_BackEnd.Site.Models.Core.Interfaces;
using ShoppingSite_BackEnd.Site.Models.EFModels;
using ShoppingSite_BackEnd.Site.Models.Entities;
using ShoppingSite_BackEnd.Site.Models.Infrastructures.ExtMethods;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoppingSite_BackEnd.Site.Models.Infrastructures.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private AppDbContext db = new AppDbContext();

		public void Create(ProductEntity entity)
		{
			db.Products.Add(entity.ToProduct());
			db.SaveChanges();
		}

		public void Delete(int docId)
		{
			var model = db.Products.Find(docId);
			if (model == null) return;

			db.Products.Remove(model);
			db.SaveChanges();
		}

		public ProductEntity Load(int docId)
		{
			var model = db.Products.Find(docId);

			return model == null ? null : model.ToProductEntity();
		}

		public IEnumerable<ProductEntity> Search(string name, string description)
		{
			var query = db.Products.AsQueryable();

			if (!string.IsNullOrEmpty(name))
			{
				query = query.Where(x => x.Name.Contains(name));
			}

			if (!string.IsNullOrEmpty(description))
			{
				query = query.Where(x => x.Description.Contains(description));
			}

			var data = query.OrderBy(x => x.Name).ToList(); // 要先寫這段，原因是EF會自動轉成SQL語法，如果是直接寫Entity的話，會轉失敗

			var result = data.Select(x => x.ToProductEntity());

			return result;
		}

		public void Update(ProductEntity entity)
		{
			Product model = db.Products.Find(entity.Id);
			if (model == null) return;

			model.CategoryId = entity.CategoryId;
			model.Name = entity.Name;
			model.Description = entity.Description;
			model.Price = entity.Price;
			model.Status = entity.Status;
			model.ProductImage = entity.ProductImage;
			model.Stock = entity.Stock;

			db.SaveChanges();
		}
	}
}