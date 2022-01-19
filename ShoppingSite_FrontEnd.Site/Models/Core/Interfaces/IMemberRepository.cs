using ShoppingSite_FrontEnd.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSite_FrontEnd.Site.Models.Core.Interfaces
{
	public interface IMemberRepository
	{
		bool IsExist(string account);

		void Create(MemberEntity entity);

		MemberEntity Load(string account);
	}
}
