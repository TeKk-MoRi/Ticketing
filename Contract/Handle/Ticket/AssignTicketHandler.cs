using AutoMapper;
using Contract.Command.Ticket;
using Contract.Messaging.Ticket;
using MediatR;
using Service.Core.Identity;
using Service.Core.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Handle.Ticket
{
    public class AssignTicketHandler : IRequestHandler<AssignTicketCommand, AssignTicketResponse>
    {
        private readonly ITicketService _ticketervice;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public AssignTicketHandler(ITicketService ticketervice, IMapper mapper
           , IUserService userService)
        {
            this._ticketervice = ticketervice;
            this._mapper = mapper;
            this._userService = userService;
        }
        public async Task<AssignTicketResponse> Handle(AssignTicketCommand request, CancellationToken cancellationToken)
        {
            AssignTicketResponse response = new();
            try
            {

                var ticket = await _ticketervice.GetByIdAsync(request.Request.ViewModel.Id);
                if (ticket is not null)
                {
                    if (!string.IsNullOrEmpty(request.Request.ViewModel.Operator))
                    {
                        var user = await _userService.GetById(request.Request.ViewModel.Operator);
                        if (user != null)
                        {
                            var role = await _userService.GetRolesAsync(user);
                            // check role if they are proper user for ticket assignment

                            ticket.OperatorId = request.Request.ViewModel.Operator;
                            var res = await _ticketervice.UpdateAndSaveAsync(ticket);

                        }
                        else
                        {
                            response.Failed();
                            response.FailedMessage();
                            response.FailedMessage("User not Found");
                            return response;

                        }
                    }
                    else
                    {
                        response.Failed();
                        response.FailedMessage();
                        response.FailedMessage("Operator could not be null");
                        return response;
                    }
                }
                response.Result = true;
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
