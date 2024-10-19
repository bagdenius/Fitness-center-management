using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ViewModels;

namespace CommandsAndQueries
{
    public class AddUserCommand : IRequest<Guid>
    {
        public Guid? ClubPassId { get; set; }
        public Guid? WorkoutId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
    }
}
