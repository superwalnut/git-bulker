using System;
using Autofac;
using AutofacSerilogIntegration;
using Gitbulker.Repository.Modules;
using Gitbulker.Service.Modules;

namespace Gitbulker.Api.Modules
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterLogger();
            builder.RegisterModule<RepositoriesModule>();
            builder.RegisterModule<ServicesModule>();
        }
    }
}
