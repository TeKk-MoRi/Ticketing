using Contract.Messaging.Ticket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Command.Ticket
{
    public record AssignTicketCommand(AssignTicketRequest Request) : IRequest<AssignTicketResponse>;
}
