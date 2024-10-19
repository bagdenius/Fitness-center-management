using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandsAndQueries;
using AutoMapper;

namespace UI.WebAPI
{
    public class ClubModelMapper : Profile
    {
        public ClubModelMapper() 
        {
            CreateMap<AddClubModel, AddClubCommand>();
            CreateMap<UpdateClubModel, UpdateClubCommand>();
        }
    }
}
