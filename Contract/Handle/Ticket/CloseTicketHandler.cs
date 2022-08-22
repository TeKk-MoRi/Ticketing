using AutoMapper;
using Contract.Command.Ticket;
using Contract.Messaging.Ticket;
using MediatR;
using Service.Core.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Handle.Ticket
{
    public class CloseTicketHandler : IRequestHandler<CloseTicketCommand, CloseTicketResponse>
    {
        private readonly ITicketService _ticketervice;
        private readonly IMapper _mapper;
        public CloseTicketHandler(ITicketService ticketervice, IMapper mapper)
        {
            this._ticketervice = ticketervice;
            this._mapper = mapper;
        }
        public async Task<CloseTicketResponse> Handle(CloseTicketCommand request, CancellationToken cancellationToken)
        {
            CloseTicketResponse response = new();
            try
            {

                var ticket = await _ticketervice.GetByIdAsync(request.Request.ViewModel.Id);
                if (ticket is not null)
                {
                    ticket.IsClosed = true;
                    var res = await _ticketervice.UpdateAndSaveAsync(ticket);
                }
                else
                {
                    response.Failed();
                    response.FailedMessage();
                    response.FailedMessage("Ticket Not Found");
                    return response;
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
