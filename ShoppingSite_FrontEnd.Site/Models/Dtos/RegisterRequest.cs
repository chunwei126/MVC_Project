using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Dtos
{
	public class RegisterRequest
	{
		public string Account { get; set; }

		public string Password { get; set; }

		public string Email { get; set; }

		public string Name { get; set; }

		public string Mobile { get; set; }
	}
}