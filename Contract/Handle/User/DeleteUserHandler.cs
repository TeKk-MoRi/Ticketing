using AutoMapper;
using Contract.Command.User;
using Contract.Messaging.User;
using MediatR;
using Service.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Handle.User
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public DeleteUserHandler(IUserService userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
        }
        public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            DeleteUserResponse response = new();

            try
            {
                var user = await _userService.FindByIdAsync(request.Request.ViewModel.Id);

                if (user is null)
                {
                    response.Failed();
                    response.FailedMessage("User Not Found");
                    return response;
                }

                var res = await _userService.DeleteUserById(user.Id);

                if (!res.Succeeded)
                {
                    response.Failed();
                    response.FailedMessage();
                    return response;
                }

                response.Succeed();
                response.SuccessMessage();
                return response;
            }
            catch (Exception ex)
            {
                response.Failed();
                response.FailedMessage();
                response.FailedMessage(ex.Message);
                return response;
            }
        }
    }
}
