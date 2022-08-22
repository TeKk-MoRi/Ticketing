using Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = Domain;

namespace Service.Core.Ticket
{
    public interface ITicketService : IBaseService<Entity.Models.Ticket.Ticket , long>
    {
        Task<List<Entity.Models.Ticket.Ticket>> GetAllTicketsByOwenrId(string ownerId);
    }
}
