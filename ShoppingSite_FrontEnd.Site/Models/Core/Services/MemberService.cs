using ShoppingSite_FrontEnd.Site.Models.Core.Interfaces;
using ShoppingSite_FrontEnd.Site.Models.Dtos;
using ShoppingSite_FrontEnd.Site.Models.Entities;
using ShoppingSite_FrontEnd.Site.Models.Infrastructures.ExtMethods;
using ShoppingSite_FrontEnd.Site.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_FrontEnd.Site.Models.Core.Services
{
	public class MemberService : IMemberService
	{
		private readonly IMemberRepository _memberRepository;

		public MemberService(IMemberRepository memberRepository)
		{
			_memberRepository = memberRepository;
		}

		public RegisterResponse CreateNewMember(RegisterRequest registerRequest)
		{
			//	判斷帳號是否已存在
			if (_memberRepository.IsExist(registerRequest.Account))
			{
				return new RegisterResponse { IsSuccess = false, ErrorMessage = "帳號已存在" };
			}

			MemberEntity memberEntity = registerRequest.ToMemberEntity();
			_memberRepository.Create(memberEntity);


			// 因為 ConfirmCode 寫在 ToMemberEntity() 的擴充方法裡面，所以這邊再利用 memberEntity 來傳 ConfirmCode 給 registerResponseData
			RegisterResponseData registerResponseData = memberEntity.ToRegisterResponseData();

			return new RegisterResponse
			{
				Data = registerResponseData,
				IsSuccess = true,
			};
		}
	}
}