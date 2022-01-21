using ShoppingSite_FrontEnd.Site.Models.EFModels;
using ShoppingSite_FrontEnd.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods
{
	public static class MemberEFMExts
	{
		public static MemberEntity ToMemberEntity(this Member source)
		{
			if (source == null) return null;

			return new MemberEntity
			{
				//Id = source.Id,
				//Account = source.Account,
				Password = source.Password,
				//Email = source.Email,
				//Name = source.Name,
				//Mobile = source.Mobile,
				IsConfirmed = source.IsConfirmed,
				ConfirmCode = source.ConfirmCode
			};
		}

		public static CustomerEntity ToCustomerEntity(this Member source)
			=> new CustomerEntity 
			{ 
				Id = source.Id, 
				CustomerAccount = source.Account 
			};
	}
}