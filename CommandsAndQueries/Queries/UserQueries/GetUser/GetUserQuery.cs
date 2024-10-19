using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ViewModels;

namespace CommandsAndQueries
{
    public class GetUserQuery : IRequest<UserModel>
    {
        public Guid Id { get; set; }

    }
}
