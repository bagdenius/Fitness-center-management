using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandsAndQueries;
using AutoMapper;

namespace UI.WebAPI
{
    public class WorkoutModelMapper : Profile
    {
        public WorkoutModelMapper()
        {
            CreateMap<AddWorkoutModel, AddWorkoutCommand>();
            CreateMap<UpdateWorkoutModel, UpdateWorkoutCommand>();
        }
    }
}
