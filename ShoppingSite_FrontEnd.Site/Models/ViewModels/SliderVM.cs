using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.ViewModels
{
	public class SliderVM 
	{
		//public SliderVM(IEnumerable<ProductVM> latestProductsData, IEnumerable<HotProductVM> hotProductsData)
		//{
		//	latestProductsData = this.LatestProductsData;
		//	hotProductsData = this.HotProductsData;
		//}

		public IEnumerable<ProductVM> LatestProductsData  { get; set; }

		public IEnumerable<HotProductVM> HotProductsData { get; set; }
	}
}