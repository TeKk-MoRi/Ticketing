using Contract.Messaging.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Query
{
    public record GetAllUsersQuery(GetAllUsersRequest Request) : IRequest<GetAllUsersResponse>;
}
