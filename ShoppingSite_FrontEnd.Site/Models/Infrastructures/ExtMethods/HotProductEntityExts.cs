using ShoppingSite_FrontEnd.Site.Models.EFModels;
using ShoppingSite_FrontEnd.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods
{
	public static class HotProductEntityExts
	{
    public static HotProductVM ToVM(this HotProductEntity source)
          => new HotProductVM
          {
            Id = source.Id,
            Name = source.Name,
            Category = source.Category.Name,
            Description = source.Description,
            Price = source.Price,
            Stock = source.Stock,
            ProductImage = source.ProductImage,
          };
  }
}