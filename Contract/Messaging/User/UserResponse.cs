using Contract.Messaging.Base;
using Contract.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Messaging.User
{
    public class LoginResponse : BaseApiResponse<UserViewModel> { }
    public class GetTokenResponse : BaseApiResponse<AuthenticationViewModel> { }
    public class RegisterResponse : BaseApiResponse<bool> { }
    public class AddUserResponse : BaseApiResponse<bool> { }
    public class UpdateUserResponse : BaseApiResponse<bool> { }
    public class GetAuthenticatedUserByIdResponse : BaseApiResponse<UserViewModel> { }
    public class DeleteUserResponse : BaseApiResponse<bool> { }
    public class GetAllUsersResponse : BaseApiResponse<List<UserViewModel>> { }
}
