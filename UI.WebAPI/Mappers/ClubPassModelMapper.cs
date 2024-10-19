using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandsAndQueries;
using AutoMapper;

namespace UI.WebAPI
{
    public class ClubPassModelMapper : Profile
    {
        public ClubPassModelMapper()
        {
            CreateMap<AddClubPassModel, AddClubPassCommand>();
            CreateMap<UpdateClubPassModel, UpdateClubPassCommand>();
        }
    }
}
