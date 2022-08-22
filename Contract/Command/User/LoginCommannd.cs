using Contract.Messaging.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Command.User
{
    public record LoginCommand(LoginRequest Request) : IRequest<LoginResponse>;
}
