using AutoMapper;
using Contract.Messaging.Ticket;
using Contract.Query.Ticket;
using Contract.ViewModels.Ticket;
using MediatR;
using Service.Core.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Handle.Ticket
{
    public class GetAllTicketsHandler : IRequestHandler<GetAllTicketsQuery, GetAllTicketsResponse>
    {
        private readonly ITicketService _ticketervice;
        private readonly IMapper _mapper;
        public GetAllTicketsHandler(ITicketService ticketervice, IMapper mapper)
        {
            this._ticketervice = ticketervice;
            this._mapper = mapper;
        }
        public async Task<GetAllTicketsResponse> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
        {
            GetAllTicketsResponse response = new();
            try
            {
                var tickets = await _ticketervice.GetAllTicketsByOwenrId(request.Request.Owner);
                if (tickets is null || tickets.Count == 0)
                {
                    response.Succeed();
                    response.SuccessMessage();
                    response.SuccessMessage("There is no ticket");
                    return response;
                }
                var res = _mapper.Map<List<GetAllTicketsViewModel>>(tickets);
                response.Result = res;
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
