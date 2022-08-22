using Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = Domain;

namespace Service.Core.TicketCategory
{
    public interface ITicketCategoryService : IBaseService<Entity.Models.Ticket.TicketCategory>
    {
        Task InsertBulk(List<Domain.Models.Ticket.TicketCategory> ticketCategories);
        Task UpdateBulk(List<Domain.Models.Ticket.TicketCategory> ticketCategories);
    }
}
