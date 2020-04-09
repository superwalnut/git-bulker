using System;
using Autofac;
using Gitbulker.Core.Configs;
using Gitbulker.Model.Entities;
using Gitbulker.Mongo.Interfaces;
using Gitbulker.Mongo.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Gitbulker.Mongo.Modules
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProjectRepository>().As<IProjectRepository>();
            builder.RegisterType<TagRepository>().As<ITagRepository>();
            builder.RegisterType<GitRepoRepository>().As<IGitRepoRepository>();

            builder.Register(x =>
            {
                var mongoConfig = x.Resolve<IOptions<MongoConfig>>().Value;
                return new MongoClient(mongoConfig.ConnectionString);
            }).As<IMongoClient>().SingleInstance();

            builder.Register(x =>
            {
                var mongoConfig = x.Resolve<IOptions<MongoConfig>>().Value;
                return x.Resolve<IMongoClient>().GetDatabase(mongoConfig.DatabaseName);
            }).As<IMongoDatabase>().SingleInstance();

            builder.Register(c =>
            {
                var collection = c.Resolve<IMongoDatabase>().GetCollection<Project>("Projects");
                var idx = Builders<Project>.IndexKeys.Ascending(x => x.Id);
                collection.Indexes.CreateOne(new CreateIndexModel<Project>(idx));
                return collection;
            }).As<IMongoCollection<Project>>().SingleInstance();

            builder.Register(c =>
            {
                var collection = c.Resolve<IMongoDatabase>().GetCollection<Model.Entities.Tag>("Tags");
                var idx = Builders<Model.Entities.Tag>.IndexKeys.Ascending(x => x.Id);
                collection.Indexes.CreateOne(new CreateIndexModel<Model.Entities.Tag>(idx));
                return collection;
            }).As<IMongoCollection<Model.Entities.Tag>>().SingleInstance();

            builder.Register(c =>
            {
                var collection = c.Resolve<IMongoDatabase>().GetCollection<GitRepo>("GitRepos");
                var idx = Builders<GitRepo>.IndexKeys.Ascending(x => x.Id);
                collection.Indexes.CreateOne(new CreateIndexModel<GitRepo>(idx));
                return collection;
            }).As<IMongoCollection<GitRepo>>().SingleInstance();
        }
    }
}
