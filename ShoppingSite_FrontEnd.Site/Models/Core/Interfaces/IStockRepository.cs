using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSite_FrontEnd.Site.Models.Core.Interfaces
{
	public interface IStockRepository
	{
		/// <summary>
		/// 異動庫存
		/// qty不是新庫存值，而是要異動的差異數量；負數表示扣庫存，正數表示增加庫存
		/// </summary>
		/// <param name="info"></param>
		void Update((int productId, int qty)[] info);
	}
}
