using ShoppingSite_FrontEnd.Site.Models.Entities;
using ShoppingSite_FrontEnd.Site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods
{
	public static class PollEntityExts
	{
    public static PollVM ToPollVM(this PollEntity source)
      => new PollVM
      {
        Id = source.Id,
        Name = source.Name,
        Category = source.Category.Name,
        Description = source.Description,
        Price = source.Price,
        ProductImage = source.ProductImage,
        CreateTime = source.CreateTime,
        Votes = source.Votes,
      };
  }
}