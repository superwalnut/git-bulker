using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Gitbulker.Model.Entities;
using Gitbulker.Model.Models;
using Gitbulker.Mongo.Interfaces;
using Gitbulker.Service.Interfaces;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Gitbulker.Service.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Project> Create(string name, string root, string mainBranch)
        {
            var project = new Project
            {
                Id = new ObjectId(),
                Name = name,
                Root = root,
                MainBranch = mainBranch,
                Created = DateTime.Now,
                Updated = DateTime.Now
            };

            await _projectRepository.SaveProject(project);

            return project;
        }

        public async Task<Project> GetByName(string name)
        {
            return await _projectRepository.GetProjectByName(name);
        }

        public async Task<Project> GetById(string id)
        {
            return await _projectRepository.GetProjectById(id);
        }

        public async Task<List<Project>> GetAll()
        {
            return await _projectRepository.GetAll();
        }
    }
}
