using ShoppingSite_BackEnd.Site.Models.Core.Interfaces;
using ShoppingSite_BackEnd.Site.Models.DTOs;
using ShoppingSite_BackEnd.Site.Models.EFModels;
using ShoppingSite_BackEnd.Site.Models.Entities;
using ShoppingSite_BackEnd.Site.Models.Infrastructures.ExtMethods;
using ShoppingSite_BackEnd.Site.Models.Infrastructures.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_BackEnd.Site.Models.Core.Services
{
	public class ProductService
	{
		private readonly IProductRepository _repo;

		public ProductService()
		{
			this._repo = new ProductRepository();
		}

		public ProductService(IProductRepository repo)
		{
			_repo = repo;
		}

		public void Create(ProductRequest request)
		{

			ProductEntity entity = request.ToProductEntity();

			_repo.Create(entity);
		}

		public void Update(ProductRequest request)
		{
			ProductEntity entity = this._repo.Load(request.Id);

			entity.CategoryId = request.CategoryId;
			entity.Name = request.Name;
			entity.Description = request.Description;
			entity.Price = request.Price;
			entity.Status = request.Status;
			entity.ProductImage = request.ProductImage;
			entity.Stock = request.Stock;

			_repo.Update(entity);
		}

		public void Delete(int docId)
		{
			this._repo.Delete(docId);
		}
	}
}