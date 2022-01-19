using ShoppingSite_FrontEnd.Site.Models.Core.Interfaces;
using ShoppingSite_FrontEnd.Site.Models.Dtos;
using ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods;
using ShoppingSite_FrontEnd.Site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.UseCases
{
	public class MemberCommand
	{
		private IMemberService _memberService;

		public MemberCommand(IMemberService memberService)
		{
			_memberService = memberService;
		}

		public RegisterResponse SendMail(RegisterVM registerVM)
		{
			RegisterRequest registerRequest = registerVM.ToRegisterRequest();

			RegisterResponse registerResponse = _memberService.CreateNewMember(registerRequest);

			//if (response.issuccess == true)
			//{
			//	todo send email

			//}

			return registerResponse;
		}
	}
}