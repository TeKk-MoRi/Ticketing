using Datalayer.Context;
using Microsoft.EntityFrameworkCore;
using Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = Domain;

namespace Service.Core.Ticket
{
    public class TicketService : BaseService<Entity.Models.Ticket.Ticket, long>, ITicketService
    {
        public TicketService(TicketingContext context) : base(context)
        {
        }

        public async Task<List<Entity.Models.Ticket.Ticket>> GetAllTicketsByOwenrId(string ownerId)
        {
            return await Entities.Where(x => x.OwnerId == ownerId).ToListAsync();
        }
    }
}
