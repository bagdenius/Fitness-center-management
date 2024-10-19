using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ViewModels;

namespace CommandsAndQueries
{
    public class AddClubCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
