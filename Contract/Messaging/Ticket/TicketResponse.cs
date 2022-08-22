using Contract.Messaging.Base;
using Contract.ViewModels.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Messaging.Ticket
{

    public class AddTicketResponse : BaseApiResponse<bool> { }
    public class UpdateTicketResponse : BaseApiResponse<bool> { }
    public class DeleteTicketResponse : BaseApiResponse<bool> { }
    public class CloseTicketResponse : BaseApiResponse<bool> { }
    public class AssignTicketResponse : BaseApiResponse<bool> { }
    public class GetAllTicketsResponse : BaseApiResponse<List<GetAllTicketsViewModel>> { }

}
