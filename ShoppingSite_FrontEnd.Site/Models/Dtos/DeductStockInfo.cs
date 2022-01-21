using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Dtos
{
	public class DeductStockInfo
	{
		public int ProductId { get; set; }

		/// <summary>
		/// 傳入正數
		/// </summary>
		public int Qty { get; set; }
	}
}