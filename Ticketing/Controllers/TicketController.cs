using Contract.Command.Ticket;
using Contract.Command.User;
using Contract.Messaging.Ticket;
using Contract.Messaging.User;
using Contract.Query;
using Contract.Query.Ticket;
using Contract.ViewModels.Ticket;
using Contract.ViewModels.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ticketing.Extensions;

namespace Ticketing.Controllers
{
    public class TicketController : BaseController
    {
        private readonly IMediator _mediator;
        public TicketController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Authorize(Roles = "TicketUser")]
        public async Task<IActionResult> GetAllTickets()
        {
            var user = APIHelper.GetRequestedUserInformation();
            var res = await _mediator.Send(new GetAllTicketsQuery(new GetAllTicketsRequest { Owner = user.Id }));

            return Response(res);
        }

        [HttpPost]
        [Authorize(Roles = "TicketUser")]
        public async Task<IActionResult> AddTicket(AddTicketViewModel model)
        {
            var user = APIHelper.GetRequestedUserInformation();
            var res = await _mediator.Send(new AddTicketCommand(new AddTicketRequest { ViewModel = model, Owner = user.Id }));

            return Response(res);
        }

        [HttpPost]
        [Authorize(Roles = "TicketUser")]
        public async Task<IActionResult> UpdateTicket(TicketViewModel model)
        {
            var user = APIHelper.GetRequestedUserInformation();
            var res = await _mediator.Send(new UpdateTicketCommand(new UpdateTicketRequest { ViewModel = model, Owner = user.Id }));

            return Response(res);
        }

        [HttpPost]
        [Authorize(Roles = "TicketUser")]
        public async Task<IActionResult> DeleteTicket(TicketIdViewModel model)
        {
            var user = APIHelper.GetRequestedUserInformation();
            var res = await _mediator.Send(new DeleteTicketCommand(new DeleteTicketRequest { ViewModel = model, Owner = user.Id }));

            return Response(res);
        }

        [HttpPost]
        [Authorize(Roles = "TicketAdmin")]
        public async Task<IActionResult> CloseTicket(TicketIdViewModel model)
        {
            var res = await _mediator.Send(new CloseTicketCommand(new CloseTicketRequest { ViewModel = model }));

            return Response(res);
        }

        [HttpPost]
        [Authorize(Roles = "TicketAdmin")]
        public async Task<IActionResult> AssignTicket(AssignTicketViewModel model)
        {
            var res = await _mediator.Send(new AssignTicketCommand(new AssignTicketRequest { ViewModel = model }));

            return Response(res);
        }
    }
}
