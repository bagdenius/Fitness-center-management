using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using DataBase;

namespace Repository
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContextRepository<Club>>().As<IGenericRepository<Club>>();
            builder.RegisterType<ContextRepository<ClubPass>>().As<IGenericRepository<ClubPass>>();
            builder.RegisterType<ContextRepository<User>>().As<IGenericRepository<User>>();
            builder.RegisterType<ContextRepository<Workout>>().As<IGenericRepository<Workout>>();
        }
    }
}
