using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using ViewModels;
using CommandsAndQueries;


namespace UI.WebAPI
{
    public class ModelMappingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ClubMapper>();
                cfg.AddProfile<ClubPassMapper>();
                cfg.AddProfile<UserMapper>();
                cfg.AddProfile<WorkoutMapper>();
                cfg.AddProfile<ClubModelMapper>();
                cfg.AddProfile<ClubPassModelMapper>();
                cfg.AddProfile<UserModelMapper>();
                cfg.AddProfile<WorkoutModelMapper>();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
        }
    }
}
