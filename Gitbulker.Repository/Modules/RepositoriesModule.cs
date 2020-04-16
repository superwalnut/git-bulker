using System;
using System.IO;
using Autofac;
using Gitbulker.Core.Configs;
using Gitbulker.Repository.Interfaces;
using Gitbulker.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Gitbulker.Repository.Modules
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var dbConfig = c.Resolve<IOptions<DbConfig>>().Value;

                var opt = new DbContextOptionsBuilder<GitbulkerDbContext>();

                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dbConfig.DatabasePath, dbConfig.DatabaseName);

                opt.UseSqlite($"Data Source={path};");

                return new GitbulkerDbContext(opt.Options);
            }).AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<ProjectRepository>().As<IProjectRepository>();
            builder.RegisterType<TagRepository>().As<ITagRepository>();
        }
    }
}
