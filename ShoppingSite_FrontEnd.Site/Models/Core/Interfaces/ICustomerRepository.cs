using ShoppingSite_FrontEnd.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSite_FrontEnd.Site.Models.Core.Interfaces
{
	/// <summary>
	/// 對前台購物網站而言，買家是Customer，與 Member的概念還是有一點不同，CustomerService/CustomerRepository
	/// </summary>
	public interface ICustomerRepository
	{
		/// <summary>
		/// 有權限在本網站購物的會員才傳回True
		/// </summary>
		/// <param name="customerAccount"></param>
		/// <returns></returns>
		bool IsExists(string customerAccount);


		/// <summary>
		/// 有權限在本網站購物的會員才傳回其 id 值
		/// </summary>
		/// <param name="customerAccount"></param>
		/// <returns></returns>
		int GetCustomerId(string customerAccount);


		/// <summary>
		/// 有權限在本網站購物的會員才傳回物件
		/// </summary>
		/// <param name="customerAccount"></param>
		/// <returns></returns>
		CustomerEntity Load(string customerAccount);
	}
}
