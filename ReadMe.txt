*****注意*****
建立 "Controller" 之前，要先把 "EF zh-hant" 刪除並建置


[15/....] 前置作業
[v] [1/1] 建立 "ShoppingSite_FrontEnd.Site" 專案
[v] [1/1] 建立 "Infrastructures" 專案
[v] [1/1] 新增 "ReadMe" 項目
[v] [1/1] 建立 "Models/Dtos/" 資料夾
[v] [1/1] 建立 "Models/EFModels/" 資料夾
[v] [1/1] 建立 "Models/Entities/" 資料夾
[v] [1/1] 建立 "Models/UseCases/" 資料夾
[v] [1/1] 建立 "Models/ValueObjects/" 資料夾
[v] [1/1] 建立 "Models/ViewModels/" 資料夾
--------- -------------------------------------------------
[v] [1/3] 建立 "Models/Core/" 資料夾
[v] [2/3] 建立 "Models/Core/Interfaces/" 資料夾
[v] [3/3] 建立 "Models/Core/Services/" 資料夾
--------- -------------------------------------------------
[v] [1/3] 建立 "Models/Infrastructures/" 資料夾
[v] [2/3] 建立 "Models/Infrastructures/ExtMethods/" 資料夾
[v] [3/3] 建立 "Models/Infrastructures/Repositories/" 資料夾


[4/....] 資料庫設計
[v] [1/1] 建立 "Project" 資料庫
[v] [1/1] 建立 "Faqs" 資料表
[v] [1/1] 建立 "News" 資料表
[v] [1/1] 建立 "Members" 資料表


[v] [3/3]常見問題模組
[v] [3/3]Index
	[v] [1/3]建立 "FaqsController" (EF控制器) 
	[v] [2/3]將 "Index" 以外的 action 刪除 
	[v] [3/3]將 "Index" 以外的 ViewPage 刪除


[v]	[3/3] 最新消息模組
[v] [3/3] Index
	[v] [1/3] 建立 "NewsController" (EF控制器) 
	[v] [2/3] 將 "Index" 以外的 action 刪除 
	[v] [3/3] 將 "Index" 以外的 ViewPage 刪除

[working on] [1/3]會員模組
	[v] [1/1] 註冊功能
						1.寫 MemberCommand SendMail
						2.
						3.
						4.
	[v] [0/1] 登入功能
						1.寫 MemberRepository Load (查詢是否驗證過用)
						2.寫 MemberController logIn (登入用)
						3.寫 MemberController ProcessLogin (登入cookie用)
	[v] [0/1] 登出功能 
						1.寫 MemberController logOut (登出用)
	

	


	1/19 (上午)
	寫 MemberRepository Load (查詢是否驗證過用)
	寫 MemberController logIn (登入用)
	寫 MemberController ProcessLogin (登入cookie用)
	寫 MemberController logOut (登入cookie用)

	1/19 (下午)
	

[] add /Models/UseCases/RegisterCommand class( with Execute method)
[] add /Models/Core/MemberService class(with CreateNewMember method)
[] implement MembersController.Register() function
[] implement RegisterCommand.Execute function

[]add new /Models/Infrastructures/Repositories/MemberRepository
	
	[] [1/2] 撰寫 "RegisterCommand.cs" 發信 Code
 

***新會員 Email 確認功能
[] 會員按下email裡的確認連結, MemebersController.ConfirmRegister(), Service.ActiveRegister()
[] modify IMemberRepository(Load:MemberEntity, ActiveRegister), addMemberRepository.ActiveRegister(memberId)
[] Views/Members/ConfirmRegister	

** password 編碼
[] add new /Models/Infrastructures/HashUtility.cs
[] 修改MemberEntity, add EnctryptedPassword property
[] 修改 MemberRepository,改成取用 EncryptedPassword property
[] 修改 Members table, column Password,from nvarchar(50) to nvarchar(70)
[] 同步修改 /Models/EFModels/Members.cs裡的Password data annotation

*** 登入/登出網站
[] modify web.config, add Authenthcation node
[] modify MemberController.About, add "Authorize" attribute
[] add MembersController.Logout()
[] add /Models/ViewModels/LoginVM.cs
[] add MembersController.Login(), and create "Login" view page
[] add /Models/DTOs/LoginResponse.cs
[] add MemberRepository.Login(account)
[] add MemberService.Login(account, password)
[] add MemberController.Login() httppost action
	使用表單認證,寫入 cookie
[] modify _Layout page, add "Login/Logout" links

*** 會員中心
[working on] 會員中心頁(/Members/Index)
	改 web.config
	add MembersController.Index(), Index view page

*** 修改個人基本資料(/Members/EditProfile)
[] add /ViewModels/EditProfileVM.cs
[] add MembersController.EditProfile() , add "EditProfile" view page
[] add UpdateProfileRequest class, add MemberService.UpdateProfile(UpdateProfileRequest)
	UpdateProfileRequest class 加入 string "CurrentUserAccount property
[] modify IMemberRepository=> add IsExists(account,excludeId), Update(MemberEntity)
[] 如果更新個資成功,且有改帳唬, 就自動轉向到logout page


[] 變更密碼(/Members/EditPassword/)
	add EditPasswordVM, ChangePasswordRequest
	add IMemberRepository.UpdatePassword()
[] /Members/Index/, EditProfile,EditPassword, Logout 要加[Authorize]


[] 發信還沒寫
[working on] add SendEmail Utility(at /Models/Infrastructures/EmailHelper.cs)

忘記密碼
[working on] add ForgetPasswordVM, create MembersController.ForgetPassword, add ForgetPassword view page
[working on] add MemberService.RequestResetPassword(string account, string email)

[working on] 重設密碼


======================
[v] add Product