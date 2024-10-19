using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DataBase;
using ViewModels;

namespace CommandsAndQueries
{
    public class ClubPassMapper : Profile
    {
        public ClubPassMapper() { CreateMap<ClubPass, ClubPassModel>().ReverseMap(); }
    }
}
