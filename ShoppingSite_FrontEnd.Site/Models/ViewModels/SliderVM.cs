using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.ViewModels
{
	public class SliderVM 
	{

		public IEnumerable<ProductVM> LatestProductsData  { get; set; }

		public IEnumerable<HotProductVM> HotProductsData { get; set; }
	}
}