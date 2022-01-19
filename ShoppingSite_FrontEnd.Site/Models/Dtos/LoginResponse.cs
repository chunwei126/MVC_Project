using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Dtos
{
	public class LoginResponse
	{
		public bool IsSuccess { get; set; }
		public string ErrorMessage { get; set; }

		public static LoginResponse Success() => new LoginResponse { IsSuccess = true };

		public static LoginResponse Fail(string errorMessage)
			=> new LoginResponse { IsSuccess = false, ErrorMessage = errorMessage };
	}
}