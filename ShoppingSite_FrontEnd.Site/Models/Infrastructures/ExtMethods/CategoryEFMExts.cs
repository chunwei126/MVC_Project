using ShoppingSite_FrontEnd.Site.Models.EFModels;
using ShoppingSite_FrontEnd.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods
{
	public static class CategoryEFMExts
	{
    public static CategoryEntity ToCategoryEntity(this Category source)
     => new CategoryEntity
     {
       Id = source.Id,
       Name = source.Name,
       DisplayOrder = source.DisplayOrder,
     };
  }
}