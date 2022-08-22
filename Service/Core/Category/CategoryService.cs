using Datalayer.Context;
using Service.Base;
using Service.Core.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = Domain;

namespace Service.Core.Category
{
    public class CategoryService : BaseService<Entity.Models.Ticket.Category>, ICategoryService
    {
        public CategoryService(TicketingContext context) : base(context)
        {
        }
    }
}
