using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ViewModels;

namespace CommandsAndQueries
{
    public class UpdateWorkoutCommand : IRequest
    {
        public Guid Id { get; set; }
        //public Guid ClubId { get; set; }
        public string Type { get; set; }
        public DateTime Time { get; set; }
        public double Price { get; set; }
    }
}
