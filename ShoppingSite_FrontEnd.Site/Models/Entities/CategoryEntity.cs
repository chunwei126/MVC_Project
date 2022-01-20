using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Entities
{
	public class CategoryEntity
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int DisplayOrder { get; set; }
	}
}