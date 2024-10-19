using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DataBase;
using ViewModels;

namespace CommandsAndQueries
{
    public class UserMapper : Profile
    {
        public UserMapper() { CreateMap<User, UserModel>().ReverseMap(); }
    }
}
