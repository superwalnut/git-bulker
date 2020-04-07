using System;
using Gitbulker.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gitbulker.Web.Controllers
{
    public class ProjectController
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

    }
}
