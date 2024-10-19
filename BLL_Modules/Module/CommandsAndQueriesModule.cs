using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR.Extensions.Autofac.DependencyInjection;
using CommandsAndQueries;
using System.Reflection;

namespace BLL_Modules
{
    public class CommandsAndQueriesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMediatR(typeof(AddClubCommandHandler).GetTypeInfo().Assembly);
            builder.RegisterMediatR(typeof(GetClubQueryHandler).GetTypeInfo().Assembly);
        }
    }
}
