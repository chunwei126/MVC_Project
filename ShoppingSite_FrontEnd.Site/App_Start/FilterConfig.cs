using System.Web;
using System.Web.Mvc;

namespace ShoppingSite_FrontEnd.Site
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
