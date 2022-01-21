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
	public class CustomerRepository : ICustomerRepository
	{
		private readonly AppDbContext _db;

		public CustomerRepository(AppDbContext db)
		{
			_db = db;
		}

		/// <summary>
		/// 有權限在本網站購物的會員才傳回true
		/// </summary>
		/// <param name="customerAccount"></param>
		/// <returns></returns>
		public bool IsExists(string customerAccount)
		{
			var member = _db.Members.SingleOrDefault(x => x.IsConfirmed == true && x.Account == customerAccount);

			return member != null;
		}

		public int GetCustomerId(string customerAccount)
			=> _db.Members.Single(x =>
														x.IsConfirmed == true &&
														x.Account == customerAccount).Id;

		public CustomerEntity Load(string customerAccount)
			=> _db.Members.Single(x =>
														x.IsConfirmed == true &&
														x.Account == customerAccount)
														.ToCustomerEntity();
	}
}