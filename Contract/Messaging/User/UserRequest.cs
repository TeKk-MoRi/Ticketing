using Contract.Messaging.Base;
using Contract.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Messaging.User
{
    public class LoginRequest : BaseApiRequest<LoginViewModel>
    {
        public LoginRequest(LoginViewModel viewModel)
        {
            ViewModel = viewModel;
        }
    }
    public class RegisterRequest : BaseApiRequest<RegisterViewModel> { }
    public class AddUserRequest : BaseApiRequest<AddUserViewModel> { }
    public class UpdateUserRequest : BaseApiRequest<UpdateUserViewModel> 
    {
        public string DoerId { get; set; }
    }
    public class GetAuthenticatedUserByIdRequest : BaseApiRequest
    {
        public string UserId { get; set; }
    }
    public class DeleteUserRequest : BaseApiRequest<UserIdViewModel> { }
    public class GetAllUsersRequest : BaseApiRequest<GetAllUsersViewModel> { }


}
