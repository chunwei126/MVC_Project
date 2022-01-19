using ShoppingSite_FrontEnd.Site.Models.Dtos;
using ShoppingSite_FrontEnd.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods
{
	public static class RegisterRequestExts
	{
		public static MemberEntity ToMemberEntity(this RegisterRequest source)
		{


			return new MemberEntity
			{
				Account = source.Account,
				Password = source.Password,
				Email = source.Email,
				Name = source.Name,
				Mobile = source.Mobile,
				IsConfirmed = false,
				ConfirmCode = Guid.NewGuid().ToString("N") // 建立ConfirmCode
			};
		}

		public static RegisterResponse ToRegisterResponse(this RegisterRequest source)
		{
			return new RegisterResponse
			{
				IsSuccess = true,
			};
		}
	}
}