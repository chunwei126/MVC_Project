using ShoppingSite_FrontEnd.Site.Models.EFModels;
using ShoppingSite_FrontEnd.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods
{
	public static class PollEFMExts
	{
		public static PollEntity ToPollEntity(this Poll source)//source來源
			=> new PollEntity
			{
				Id = source.Id,
				Name = source.Name,
				Category = source.Category.ToCategoryEntity(),
				Description = source.Description,
				Price = source.Price,
				ProductImage = source.ProductImage,
				CreateTime = source.CreateTime,
				Votes = source.Votes,
			};
	}
}