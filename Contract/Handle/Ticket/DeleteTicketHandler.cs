using AutoMapper;
using Contract.Command.Ticket;
using Contract.Messaging.Ticket;
using MediatR;
using Service.Core.Ticket;
using Service.Core.TicketCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Handle.Ticket
{
    public class DeleteTicketHandler : IRequestHandler<DeleteTicketCommand, DeleteTicketResponse>
    {
        private readonly ITicketService _ticketervice;
        private readonly IMapper _mapper;
        public DeleteTicketHandler(ITicketService ticketervice, IMapper mapper)
        {
            this._ticketervice = ticketervice;
            this._mapper = mapper;
        }
        public async Task<DeleteTicketResponse> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
        {
            DeleteTicketResponse response = new();
            try
            {

                var ticket = await _ticketervice.GetByIdAsync(request.Request.ViewModel.Id);
                if (ticket is not null)
                {
                    if (request.Request.Owner == ticket.Owner.Id)
                    {
                        ticket.IsDeleted = true;
                        var res = await _ticketervice.UpdateAndSaveAsync(ticket);
                    }
                    else
                    {
                        response.Failed();
                        response.FailedMessage();
                        response.FailedMessage("Access Denied");
                        return response;
                    }
                }
                else
                {
                    response.Failed();
                    response.FailedMessage();
                    response.FailedMessage("Ticket not found");
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
