using System;
using Autofac;
using Gitbulker.Service.Interfaces;
using Gitbulker.Service.Services;

namespace Gitbulker.Service.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProjectService>().As<IProjectService>();
            builder.RegisterType<DiscoverService>().As<IDiscoverService>();
            builder.RegisterType<TagService>().As<ITagService>();
        }
    }
}
