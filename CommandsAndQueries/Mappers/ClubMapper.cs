using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DataBase;
using ViewModels;

namespace CommandsAndQueries
{
    public class ClubMapper : Profile
    {
        public ClubMapper() { CreateMap<Club, ClubModel>().ReverseMap(); }
    }
}
