using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.ValueObjects
{
	public class RegisterResponseData
	{
		public string Email { get; set; }

		public string Name { get; set; }

		public string ConfirmCode { get; set; }
	}
}