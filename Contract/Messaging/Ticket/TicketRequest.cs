using Contract.Messaging.Base;
using Contract.ViewModels.Ticket;
using Contract.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Messaging.Ticket
{
    public class AddTicketRequest : BaseApiRequest<AddTicketViewModel> 
    {
        public string Owner { get; set; }
    }

    public class UpdateTicketRequest : BaseApiRequest<TicketViewModel>
    {
        public string Owner { get; set; }
    }

    public class DeleteTicketRequest : BaseApiRequest<TicketIdViewModel>
    {
        public string Owner { get; set; }
    }
    public class CloseTicketRequest : BaseApiRequest<TicketIdViewModel> { }
    public class AssignTicketRequest : BaseApiRequest<AssignTicketViewModel> { }
    public class GetAllTicketsRequest : BaseApiRequest 
    {
        public string Owner { get; set; }
    }
}
