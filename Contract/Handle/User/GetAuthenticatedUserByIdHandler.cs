using AutoMapper;
using Contract.Messaging.User;
using Contract.Query.User;
using Contract.ViewModels.User;
using MediatR;
using Microsoft.IdentityModel.Logging;
using Service.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Handle.User
{
    public class GetAuthenticatedUserByIdHandler : IRequestHandler<GetAuthenticatedUserByIdQuery, GetAuthenticatedUserByIdResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public GetAuthenticatedUserByIdHandler(IUserService userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
        }

        public async Task<GetAuthenticatedUserByIdResponse> Handle(GetAuthenticatedUserByIdQuery request, CancellationToken cancellationToken)
        {
            GetAuthenticatedUserByIdResponse response = new();

            try
            {
                var userViewModel = new UserViewModel();
                var user = await _userService.GetById(request.Request.UserId);
                if (user is null)
                {
                    response.Failed();
                    response.FailedMessage("user not found");
                }
                else
                {
                    userViewModel = _mapper.Map<UserViewModel>(user);
                    response.Succeed();
                    response.Result = userViewModel;
                }
                return response;
            }

            catch (System.Exception ex)
            {
                response.Failed();
                response.FailedMessage();
                response.FailedMessage(ex.Message);
                return response;
            }
        }
    }
}
