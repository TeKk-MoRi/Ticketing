using Contract.Messaging.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Command.Category
{
    public record DeleteCategoryCommand(DeleteCategoryRequest Request) : IRequest<DeleteCategoryResponse>;
}
