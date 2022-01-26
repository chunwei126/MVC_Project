using ShoppingSite_BackEnd.Site.Models.DTOs;
using ShoppingSite_BackEnd.Site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_BackEnd.Site.Models.Infrastructures.ExtMethods
{
	public static class ProductEditVMExts
	{
		public static ProductRequest ToProductRequest(this ProductEditVM source)
		{
			return new ProductRequest
			{
				Id = source.Id,
				CategoryId = source.CategoryId,
				Name = source.Name,
				Description = source.Description,
				Price = source.Price,
				Status = source.Status,
				ProductImage = source.ProductImage,
				Stock = source.Stock
			};
		}
	}
}