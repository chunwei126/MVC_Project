using Infrastructures.Utilities;
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

		public LoginResponse Login(string account, string password)
		{
			// 去資料庫尋找有無對應的會員紀錄
			MemberEntity memberEntity = _memberRepository.Load(account);

			// 如果找不到對應的會員紀錄會回傳 "Null"，接著再利用 "LoginResponse.Fail()" 來傳錯誤訊息(不要告訴使用者是帳號錯還是密碼錯)
			if (memberEntity == null)
			{
				return LoginResponse.Fail("帳密有誤");
			}

			// 如果會員資格尚未確認的話，利用 "LoginResponse.Fail()" 來傳錯誤訊息
			if (!memberEntity.IsConfirmed)
			{
				return LoginResponse.Fail("會員資格尚未確認");
			}

			// 針對使用者輸入的密碼進行雜湊來比對資料庫裡的雜湊過後的密碼
			string encryptedPwd = HashUtility.ToSHA256(password, MemberEntity.SALT);

			// CompareOrdinal:藉由評估每個字串中對應的 String 物件之數字值，比較兩個 Char 物件。 
			return (String.CompareOrdinal(memberEntity.Password, encryptedPwd) == 0)
				? LoginResponse.Success()
				: LoginResponse.Fail("帳密有誤");
		}
	}
}