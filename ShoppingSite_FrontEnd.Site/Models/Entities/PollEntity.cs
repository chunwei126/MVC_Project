using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Entities
{
	public class PollEntity
	{
    public int Id { get; set; }

    public string Name { get; set; }

    public CategoryEntity Category { get; set; }

    public string Description { get; set; }

    public int Price { get; set; }

    public string ProductImage { get; set; }


    public DateTime CreateTime { get; set; }

    public int Votes { get; set; }
  }
}