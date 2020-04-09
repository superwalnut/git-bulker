using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gitbulker.Model.Entities;

namespace Gitbulker.Mongo.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project> GetProjectById(string id);
        Task<Project> GetProjectByName(string name);
        Task<List<Project>> GetAll();
        Task SaveProject(Project project);
    }
}
