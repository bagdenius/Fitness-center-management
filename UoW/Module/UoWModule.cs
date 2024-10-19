using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace UoW
{
    public class UoWModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
        }
    }
}
