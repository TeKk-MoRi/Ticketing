using Contract.Command.User;
using Contract.Messaging.User;
using Contract.Query;
using Contract.ViewModels.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ticketing.Extensions;

namespace Ticketing.Controllers
{
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "UserAdmin")]
        public async Task<IActionResult> GetAllUsers(GetAllUsersViewModel model)
        {
            var res = await _mediator.Send(new GetAllUsersQuery(new GetAllUsersRequest { ViewModel = model }));

            return Response(res);
        }
        [HttpPost]
        [Authorize(Roles = "UserAdmin")]
        public async Task<IActionResult> AddUser(AddUserViewModel model)
        {
            var res = await _mediator.Send(new AddUserCommand(new AddUserRequest { ViewModel = model }));

            return Response(res);
        }
        [HttpPost]
        [Authorize(Roles = "UserAdmin")]
        public async Task<IActionResult> UpdateUser(UpdateUserViewModel model)
        {
            var user = APIHelper.GetRequestedUserInformation();
            var res = await _mediator.Send(new UpdateUserCommand(new UpdateUserRequest { ViewModel = model, DoerId = user.Id }));

            return Response(res);
        }

        [HttpPost]
        [Authorize(Roles = "UserAdmin")]
        public async Task<IActionResult> DeleteUser(UserIdViewModel model)
        {
            var res = await _mediator.Send(new DeleteUserCommand(new DeleteUserRequest { ViewModel = model }));

            return Response(res);
        }

    }
}
