using System;
using AutoMapper;
using Gitbulker.Model.Entities;

namespace Gitbulker.Api.Models
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration GetConfig()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProjectModel, Project>();
            });
            return config;            
        }
    }
}
