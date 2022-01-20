using ShoppingSite_FrontEnd.Site.Models.Entities;
using ShoppingSite_FrontEnd.Site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods
{
	public static class ProductEntityExts
	{
    public static ProductVM ToVM(this ProductEntity source)
          => new ProductVM
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