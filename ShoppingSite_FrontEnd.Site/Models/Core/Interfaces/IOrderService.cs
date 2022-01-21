using ShoppingSite_FrontEnd.Site.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSite_FrontEnd.Site.Models.Core.Interfaces
{
	public interface IOrderService
	{
		/// <summary>
		/// 新訂單建立之後觸發本事件
		/// StockService可以訂閱並扣庫存(可由mediator操作)
		/// </summary>
		event Action<IOrderService, int> OrderCreated;

		/// <summary>
		/// 由客戶提出退訂申請之後，觸發本事件
		/// StockService可以訂閱，如果退訂的訂單尚未出貨，直接加回庫存(可由mediator操作)
		/// </summary>
		event Action<IOrderService, int> RefundRequestByCustomer;

		/// <summary>
		/// 結帳，建立一筆新訂單及明細
		/// </summary>
		/// <param name="request"></param>
		void PlaceOrder(CreateOrderRequest request);

		/// <summary>
		/// 只有客戶本人才能提出退訂申請； 訂單必須符合退訂條件才行
		/// 訂單必須還沒完成出貨，或出貨七天以內，才允許由使用者退貨；本功能只供會員"提出退訂申請"，會註記在Order.RequestRefund
		/// 如果訂單尚未出貨，直接同意退訂；若已出貨，須由後台審核之後才算正式成立並更新庫存
		/// </summary>
		/// <param name="customerAccount"></param>
		/// <param name="orderId"></param>
		void Refund(string customerAccount, int orderId);
	}
}
