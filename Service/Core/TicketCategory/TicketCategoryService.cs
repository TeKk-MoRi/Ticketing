using Datalayer.Context;
using Service.Base;
using Service.Core.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = Domain;

namespace Service.Core.TicketCategory
{
    public class TicketCategoryService : BaseService<Entity.Models.Ticket.TicketCategory>, ITicketCategoryService
    {
        public TicketCategoryService(TicketingContext context) : base(context)
        {
        }

        public async Task InsertBulk(List<Entity.Models.Ticket.TicketCategory> ticketCategories)
        {
            await Entities.BulkInsertAsync(ticketCategories);
        }

        public async Task UpdateBulk(List<Entity.Models.Ticket.TicketCategory> ticketCategories)
        {
            await Entities.BulkUpdateAsync(ticketCategories);
        }
    }
}
