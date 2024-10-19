using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ViewModels;

namespace CommandsAndQueries
{
    public class GetWorkoutListQuery : IRequest<List<WorkoutModel>>
    {
    }
}
