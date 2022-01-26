using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_BackEnd.Site.Models.DTOs
{
	public class ProductRequest
	{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public int Price { get; set; }

    public bool Status { get; set; }


    public string ProductImage { get; set; }

    public int Stock { get; set; }
  }
}