using ShoppingSite_FrontEnd.Site.Models.Core.Interfaces;
using ShoppingSite_FrontEnd.Site.Models.EFModels;
using ShoppingSite_FrontEnd.Site.Models.Entities;
using ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Infrastructures.Repositories
{
	public class MemberRepository : IMemberRepository
	{
		private readonly AppDbContext _db;
		public MemberRepository(AppDbContext db)
		{
			_db = db;
		}

		public bool IsExist(string account)
		{
			var entity = _db.Members.SingleOrDefault(x => x.Account == account);

			if (entity == null)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public void Create(MemberEntity entity)
		{
			// 轉成EF
			Member member = new Member
			{
				Account = entity.Account,
				Password = entity.EncryptedPassword,
				Email = entity.Email,
				Name = entity.Name,
				Mobile = entity.Mobile,
				IsConfirmed = entity.IsConfirmed,
				ConfirmCode = entity.ConfirmCode
			};

			_db.Members.Add(member);
			_db.SaveChanges();
		}

		/// <summary>
		/// 透過帳號來比對資料庫裡是否有對應的會員紀錄
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public MemberEntity Load(string account)
			=> _db.Members
				.SingleOrDefault(x => x.Account == account)
				.ToMemberEntity();
	}
}