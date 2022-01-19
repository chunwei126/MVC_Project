using ShoppingSite_FrontEnd.Site.Models.Entities;
using ShoppingSite_FrontEnd.Site.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Dtos
{
	public class RegisterResponse
	{
		public bool IsSuccess { get; set; }
		public string ErrorMessage { get; set; }
		public RegisterResponseData Data { get; set; }
	}
}