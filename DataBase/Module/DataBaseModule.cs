using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace DataBase
{
    public class DataBaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FitnessContext>().
                WithParameter("options", DbContextOptionsFactory.Get()).AsSelf().SingleInstance();
        }
    }
}
