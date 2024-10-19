using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandsAndQueries;
using AutoMapper;

namespace UI.WebAPI
{
    public class UserModelMapper : Profile
    {
        public UserModelMapper()
        {
            CreateMap<AddUserModel, AddUserCommand>();
            CreateMap<UpdateUserModel, UpdateUserCommand>();
        }
    }
}
