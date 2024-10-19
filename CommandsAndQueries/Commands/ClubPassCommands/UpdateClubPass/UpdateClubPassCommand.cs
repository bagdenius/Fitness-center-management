using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ViewModels;

namespace CommandsAndQueries
{
    public class UpdateClubPassCommand : IRequest
    {
        public Guid Id { get; set; }
        //public Guid ClubId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsNet { get; set; }
        public int AvailableNumberOfVisits { get; set; }
    }
}
