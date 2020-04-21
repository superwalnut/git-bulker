using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Gitbulker.Model.Entities;
using Gitbulker.Service.Interfaces;
using Gitbulker.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Gitbulker.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IDiscoverService _discoverService;

        public ProjectController(IProjectService projectService, IDiscoverService discoverService)
        {
            _projectService = projectService;
            _discoverService = discoverService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var projects = await _projectService.GetAll();
            return View(projects);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProjectViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectViewModel project)
        {
            if (ModelState.IsValid)
            {
                var developmentBranch = project.DevelopmentBranch??project.OtherBranch;
                
                var newProject = await _projectService.Create(project.Name, project.Root, developmentBranch);
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        [HttpGet]
        public async Task<IActionResult> Discover(string id)
        {
            var project = await _projectService.GetById(id);
            var repos = _discoverService.DiscoverRepositories(project);

            var orderedRepos = repos
                .OrderByDescending(x => x.FriendlyName != x.MainBranchFriendlyName?1:0)
                .ThenByDescending(x=>x.HasPendingChanges?1:0)
                .ThenByDescending(x=>x.LocalLastCommitTime)
                .ToList();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<GitRepo, GitRepoViewModel>();
            });

            IMapper imap = config.CreateMapper();
            var models = imap.Map<List<GitRepo>, List<GitRepoViewModel>>(orderedRepos);

            return View(models);
        }
    }
}
