using Contract.Messaging.Category;
using Contract.Messaging.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Query.Category
{
    public record GetAllCategoriesQuery() : IRequest<GetAllCategoriesResponse>;
}
