using System;
using System.IO;
using Gitbulker.Model.Models;
using Gitbulker.Service.Interfaces;
using Newtonsoft.Json;

namespace Gitbulker.Service.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IStoreService _storeService;

        public ProjectService(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public Project Create(string name, string root, string mainBranch)
        {
            var project = new Project
            {
                Id = name,
                Root = root,
                MainBranch = mainBranch,
            };

            _storeService.CreateProject(project.Id);

            _storeService.SaveProject(project);

            return project;
        }

        public Project Load(string id)
        {
            return _storeService.LoadProject(id);
        }
    }
}
