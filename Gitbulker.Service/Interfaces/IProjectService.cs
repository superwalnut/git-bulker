using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gitbulker.Model.Entities;
using Gitbulker.Model.Models;

namespace Gitbulker.Service.Interfaces
{
    public interface IProjectService
    {
        Task<Project> Save(Project project);

        Task<Project> GetById(int id);

        Task<List<Project>> GetAll();

        Task<Project> Delete(int id);
    }
}
