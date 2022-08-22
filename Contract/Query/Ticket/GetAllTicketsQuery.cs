using Contract.Messaging.Ticket;
using Contract.Messaging.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Query.Ticket
{
    public record GetAllTicketsQuery(GetAllTicketsRequest Request) : IRequest<GetAllTicketsResponse>;
}

