using ShoppingSite_FrontEnd.Site.Models.EFModels;
using ShoppingSite_FrontEnd.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods
{
	public static class HotProductEFMExts
	{
		public static HotProductEntity ToProductEntity(this HotProduct source)//source來源
			=> new HotProductEntity
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
	}
}