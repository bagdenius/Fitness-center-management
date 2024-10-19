using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CommandsAndQueries
{
    public class RemoveUserCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
