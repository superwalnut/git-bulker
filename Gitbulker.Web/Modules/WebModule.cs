using System;
using Autofac;
using AutofacSerilogIntegration;
using Gitbulker.Mongo.Modules;
using Gitbulker.Service.Modules;
using Gitbulker.Web.Models;

namespace Gitbulker.Web.Modules
{   
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterLogger();
            builder.RegisterModule<RepositoriesModule>();
            builder.RegisterModule<ServicesModule>();

            GitRepoViewModel.AutoMapped();
        }
    }
}
