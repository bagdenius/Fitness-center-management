using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ViewModels;

namespace CommandsAndQueries
{
    public class GetClubQuery : IRequest<ClubModel>
    {
        public Guid Id { get; set; }

    }
}
