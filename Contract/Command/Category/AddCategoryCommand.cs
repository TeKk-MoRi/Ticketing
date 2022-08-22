using Contract.Messaging.Category;
using Contract.Messaging.Ticket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Command.Category
{
    public record AddCategoryCommand(AddCategoryRequest Request) : IRequest<AddCategoryResponse>;
}
