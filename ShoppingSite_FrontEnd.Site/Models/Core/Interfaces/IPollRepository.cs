using ShoppingSite_FrontEnd.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSite_FrontEnd.Site.Models.Core.Interfaces
{
	public interface IPollRepository
	{
		IEnumerable<PollEntity> Search();

		void UpdateVote(int productId, int qty);
	}
}
