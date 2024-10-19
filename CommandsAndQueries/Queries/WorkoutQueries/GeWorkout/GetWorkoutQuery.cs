using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ViewModels;

namespace CommandsAndQueries
{
    public class GetWorkoutQuery : IRequest<WorkoutModel>
    {
        public Guid Id { get; set; }

    }
}
