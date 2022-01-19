*****�`�N*****
�إ� "Controller" ���e�A�n���� "EF zh-hant" �R���ëظm


[15/....] �e�m�@�~
[v] [1/1] �إ� "ShoppingSite_FrontEnd.Site" �M��
[v] [1/1] �إ� "Infrastructures" �M��
[v] [1/1] �s�W "ReadMe" ����
[v] [1/1] �إ� "Models/Dtos/" ��Ƨ�
[v] [1/1] �إ� "Models/EFModels/" ��Ƨ�
[v] [1/1] �إ� "Models/Entities/" ��Ƨ�
[v] [1/1] �إ� "Models/UseCases/" ��Ƨ�
[v] [1/1] �إ� "Models/ValueObjects/" ��Ƨ�
[v] [1/1] �إ� "Models/ViewModels/" ��Ƨ�
--------- -------------------------------------------------
[v] [1/3] �إ� "Models/Core/" ��Ƨ�
[v] [2/3] �إ� "Models/Core/Interfaces/" ��Ƨ�
[v] [3/3] �إ� "Models/Core/Services/" ��Ƨ�
--------- -------------------------------------------------
[v] [1/3] �إ� "Models/Infrastructures/" ��Ƨ�
[v] [2/3] �إ� "Models/Infrastructures/ExtMethods/" ��Ƨ�
[v] [3/3] �إ� "Models/Infrastructures/Repositories/" ��Ƨ�


[4/....] ��Ʈw�]�p
[v] [1/1] �إ� "Project" ��Ʈw
[v] [1/1] �إ� "Faqs" ��ƪ�
[v] [1/1] �إ� "News" ��ƪ�
[v] [1/1] �إ� "Members" ��ƪ�


[v] [3/3]�`�����D�Ҳ�
[v] [3/3]Index
	[v] [1/3]�إ� "FaqsController" (EF���) 
	[v] [2/3]�N "Index" �H�~�� action �R�� 
	[v] [3/3]�N "Index" �H�~�� ViewPage �R��


[v]	[3/3] �̷s�����Ҳ�
[v] [3/3] Index
	[v] [1/3] �إ� "NewsController" (EF���) 
	[v] [2/3] �N "Index" �H�~�� action �R�� 
	[v] [3/3] �N "Index" �H�~�� ViewPage �R��

[working on] [1/3]�|���Ҳ�
	[v] [1/1] ���U�\��
						1.�g MemberCommand SendMail
						2.
						3.
						4.
	[v] [0/1] �n�J�\��
						1.�g MemberRepository Load (�d�߬O�_���ҹL��)
						2.�g MemberController logIn (�n�J��)
						3.�g MemberController ProcessLogin (�n�Jcookie��)
	[v] [0/1] �n�X�\�� 
						1.�g MemberController logOut (�n�X��)
	

	


	1/19 (�W��)
	�g MemberRepository Load (�d�߬O�_���ҹL��)
	�g MemberController logIn (�n�J��)
	�g MemberController ProcessLogin (�n�Jcookie��)
	�g MemberController logOut (�n�Jcookie��)

	1/19 (�U��)
	

[] add /Models/UseCases/RegisterCommand class( with Execute method)
[] add /Models/Core/MemberService class(with CreateNewMember method)
[] implement MembersController.Register() function
[] implement RegisterCommand.Execute function

[]add new /Models/Infrastructures/Repositories/MemberRepository
	
	[] [1/2] ���g "RegisterCommand.cs" �o�H Code
 

***�s�|�� Email �T�{�\��
[] �|�����Uemail�̪��T�{�s��, MemebersController.ConfirmRegister(), Service.ActiveRegister()
[] modify IMemberRepository(Load:MemberEntity, ActiveRegister), addMemberRepository.ActiveRegister(memberId)
[] Views/Members/ConfirmRegister	

** password �s�X
[] add new /Models/Infrastructures/HashUtility.cs
[] �ק�MemberEntity, add EnctryptedPassword property
[] �ק� MemberRepository,�令���� EncryptedPassword property
[] �ק� Members table, column Password,from nvarchar(50) to nvarchar(70)
[] �P�B�ק� /Models/EFModels/Members.cs�̪�Password data annotation

*** �n�J/�n�X����
[] modify web.config, add Authenthcation node
[] modify MemberController.About, add "Authorize" attribute
[] add MembersController.Logout()
[] add /Models/ViewModels/LoginVM.cs
[] add MembersController.Login(), and create "Login" view page
[] add /Models/DTOs/LoginResponse.cs
[] add MemberRepository.Login(account)
[] add MemberService.Login(account, password)
[] add MemberController.Login() httppost action
	�ϥΪ��{��,�g�J cookie
[] modify _Layout page, add "Login/Logout" links

*** �|������
[working on] �|�����߭�(/Members/Index)
	�� web.config
	add MembersController.Index(), Index view page

*** �ק�ӤH�򥻸��(/Members/EditProfile)
[] add /ViewModels/EditProfileVM.cs
[] add MembersController.EditProfile() , add "EditProfile" view page
[] add UpdateProfileRequest class, add MemberService.UpdateProfile(UpdateProfileRequest)
	UpdateProfileRequest class �[�J string "CurrentUserAccount property
[] modify IMemberRepository=> add IsExists(account,excludeId), Update(MemberEntity)
[] �p�G��s�Ӹꦨ�\,�B����b��, �N�۰���V��logout page


[] �ܧ�K�X(/Members/EditPassword/)
	add EditPasswordVM, ChangePasswordRequest
	add IMemberRepository.UpdatePassword()
[] /Members/Index/, EditProfile,EditPassword, Logout �n�[[Authorize]


[] �o�H�٨S�g
[working on] add SendEmail Utility(at /Models/Infrastructures/EmailHelper.cs)

�ѰO�K�X
[working on] add ForgetPasswordVM, create MembersController.ForgetPassword, add ForgetPassword view page
[working on] add MemberService.RequestResetPassword(string account, string email)

[working on] ���]�K�X


======================
[v] add Product