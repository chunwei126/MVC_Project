using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Entities
{
	public class ProductEntity
	{
    public int Id { get; set; }

    public string Name { get; set; }

    public CategoryEntity Category { get; set; }

    public string Description { get; set; }

    public int Price { get; set; }

    public bool Status { get; set; }

    public string ProductImage { get; set; }

    public int Stock { get; set; }
  }
}