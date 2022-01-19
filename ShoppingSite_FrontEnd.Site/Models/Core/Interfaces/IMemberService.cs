using ShoppingSite_FrontEnd.Site.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSite_FrontEnd.Site.Models.Core.Interfaces
{
	public interface IMemberService
	{
		RegisterResponse CreateNewMember(RegisterRequest request);

		LoginResponse Login(string account, string password);
	}
}
