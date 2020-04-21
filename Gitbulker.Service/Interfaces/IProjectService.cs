using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gitbulker.Model.Entities;
using Gitbulker.Model.Models;

namespace Gitbulker.Service.Interfaces
{
    public interface IProjectService
    {
        Task<Project> Create(string name, string root, string mainBranch);

        Task<Project> GetByName(string name);

        Task<Project> GetById(string id);

        Task<List<Project>> GetAll();
    }
}
