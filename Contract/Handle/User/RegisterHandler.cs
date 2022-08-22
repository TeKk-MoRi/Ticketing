using AutoMapper;
using Contract.Command.User;
using Contract.Messaging.User;
using Contract.ViewModels.User;
using Domain.Models.Identity;
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
    public class RegisterHandler : IRequestHandler<RegisterCommand, RegisterResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public RegisterHandler(IUserService userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
        }
        public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            RegisterResponse response = new();
            try
            {

                var userExists = await _userService.FindByUserameAsync(request.Request.ViewModel.Username);
                if (userExists == null)
                {

                    //Create ASP User
                    var registeredApllicationUser = await AddApplicationUser(request.Request, "User");

                    if (string.IsNullOrEmpty(registeredApllicationUser.Item2))
                    {
                        response.Failed();
                        response.FailedMessage("Application user Registration failed!");
                        return response;
                    }

                    //Add "User" Role to Created User
                    if (!await _userService.CheckRoleExistance("User"))
                        await _userService.AddRole("User");
                    if (await _userService.CheckRoleExistance("User"))
                    {
                        await _userService.AddRoleToUser(registeredApllicationUser.Item1, "User");
                    }
                    //if everything goes well then...
                    response.Result = true;
                    response.Succeed();
                    response.SuccessMessage();
                    return response;
                }
                else
                {
                    response.Failed();
                    response.FailedMessage("Application user is already exist!");
                    return response;
                }
            }
            catch (System.Exception ex)
            {
                response.Failed();
                response.FailedMessage();
                response.FailedMessage(ex.Message);
                return response;
            }
        }
        private async Task<Tuple<ApplicationUser, string>> AddApplicationUser(RegisterRequest request, string roleName)
        {
            RegisterApplicationUserViewModel registerApplicationUserViewModel = new RegisterApplicationUserViewModel()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.ViewModel.Username,
                RoleName = roleName,
                IsActive = true,
                Email = request.ViewModel.Email
            };
            ApplicationUser applicationUser = _mapper.Map<ApplicationUser>(registerApplicationUserViewModel);
            var registeredApllicationUser = await _userService.AddUser(applicationUser, request.ViewModel.Password);
            return Tuple.Create(applicationUser, registeredApllicationUser);
        }
    }
}
