using ShoppingSite_FrontEnd.Site.Models.Dtos;
using ShoppingSite_FrontEnd.Site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods
{
	public static class RegisterVMExts
	{
		public static RegisterRequest ToRegisterRequest(this RegisterVM source)
		{
			return new RegisterRequest
			{
				Account = source.Account,
				Password = source.Password,
				Email = source.Email,
				Name = source.Name,
				Mobile = source.Mobile,
			};
		}
	}
}