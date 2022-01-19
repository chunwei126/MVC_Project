using ShoppingSite_FrontEnd.Site.Models.Entities;
using ShoppingSite_FrontEnd.Site.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods
{
	public static class MemberEntityExts
	{
		public static RegisterResponseData ToRegisterResponseData(this MemberEntity source)
		{
			return new RegisterResponseData
			{
				Name = source.Name,
				Email = source.Email,
				ConfirmCode = source.ConfirmCode
			};
		}
	}
}