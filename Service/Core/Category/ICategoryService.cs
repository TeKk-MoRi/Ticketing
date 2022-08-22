using Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = Domain;

namespace Service.Core.Category
{
    public interface ICategoryService : IBaseService<Entity.Models.Ticket.Category>
    {
    }
}
