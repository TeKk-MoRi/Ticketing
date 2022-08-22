using AutoMapper;
using Contract.Command.User;
using Contract.Messaging.User;
using Contract.Query;
using Contract.Query.User;
using Contract.ViewModels.User;
using MediatR;
using Service.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Handle.User
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, GetAllUsersResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public GetAllUsersHandler(IUserService userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
        }
        public async Task<GetAllUsersResponse> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            GetAllUsersResponse response = new();

            try
            {
                var result = await _userService.GetAllUsers(request.Request.ViewModel.Take);
                response.Result = _mapper.Map<List<UserViewModel>>(result);
                response.Succeed();
            }
            catch (Exception e)
            {
                response.Failed();
                response.FailedMessage();
                response.FailedMessage(e.Message);
            }

            return response;
        }
    }
}
