using ShoppingSite_FrontEnd.Site.Models.EFModels;
using ShoppingSite_FrontEnd.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods
{
	public static class ProductEFMExts
	{
		public static ProductEntity ToProductEntity(this Product source)//source來源
			=> new ProductEntity
			{
				Id = source.Id,
				Name = source.Name,
				Category = source.Category.ToCategoryEntity(),
				Description = source.Description,
				Price = source.Price,
				Stock = source.Stock,
				Status = source.Status,
				ProductImage = source.ProductImage,
			};

		public static CartProductEntity ToCartProduct(this Product source)
			=> new CartProductEntity
			{
				Id = source.Id,
				Name = source.Name,
				Price = source.Price
			};

		public static OrderProductEntity ToOrderProductEntity(this Product source)
			=> new OrderProductEntity(source.Id, source.Name, source.Price);
	}
}