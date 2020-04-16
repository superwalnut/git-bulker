using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Gitbulker.Model.Entities;
using Gitbulker.Model.Models;
using Gitbulker.Repository.Interfaces;
using Gitbulker.Service.Interfaces;

namespace Gitbulker.Service.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Project> Save(Project project)
        {
            if (project.Id > 0)
            {
                project.Updated = DateTime.Now;
                return await _projectRepository.Update(project);
            }
            else
            {
                project.Created = DateTime.Now;
                project.Updated = DateTime.Now;
                return await _projectRepository.Add(project);
            }            
        }

        public async Task<Project> GetById(int id)
        {
            return await _projectRepository.Get(id);
        }

        public async Task<List<Project>> GetAll()
        {
            return await _projectRepository.GetAll();
        }

        public async Task<Project> Delete(int id)
        {
            return await _projectRepository.Delete(id);
        }
    }
}
