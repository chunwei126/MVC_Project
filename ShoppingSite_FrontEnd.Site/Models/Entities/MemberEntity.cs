using Infrastructures.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Entities
{
	public class MemberEntity : MemberEntityWithoutPassword
	{
		public string Password { get; set; }

		public string EncryptedPassword
		{
			get
			{
				string salt = SALT;
				string result = HashUtility.ToSHA256(this.Password, salt);
				return result;
			}
		}
	}

	public class MemberEntityWithoutPassword
	{
		public const string SALT = "!@#$$DGTEGYT";

		public int Id { get; set; }

		public string Account { get; set; }

		public string Email { get; set; }

		public string Name { get; set; }

		public string Mobile { get; set; }

		public int Age { get; set; }

		public bool Gender { get; set; }

		public bool IsConfirmed { get; set; }

		public string ConfirmCode { get; set; }
	}
}
