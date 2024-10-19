using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DataBase;
using ViewModels;

namespace CommandsAndQueries
{
    public class WorkoutMapper : Profile
    {
        public WorkoutMapper() { CreateMap<Workout, WorkoutModel>().ReverseMap(); }
    }
}
