using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Gitbulker.Api.Models;
using Gitbulker.Model.Entities;
using Gitbulker.Service.Interfaces;
using LibGit2Sharp;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Gitbulker.Api.Controllers
{
    [Route("api/[controller]")]
    public class GitRepoController : Controller
    {
        private readonly IDiscoverService _discoverService;
        private readonly IProjectService _projectService;
        private readonly IGitRepoService _gitRepoService;
        private readonly ILogger _logger;

        public GitRepoController(IDiscoverService discoverService, IProjectService projectService, IGitRepoService gitRepoService, ILogger logger)
        {
            _discoverService = discoverService;
            _projectService = projectService;
            _gitRepoService = gitRepoService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<List<GitRepo>> GetRepositoriesByProjectId(int id)
        {
            var project = await _projectService.GetById(id);

            var repos = _discoverService.DiscoverRepositories(project);

            return repos;
        }

        [HttpPost("switch")]
        public IActionResult SwitchBranches([FromBody]BranchesActionModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _gitRepoService.SwitchBranches(model.GitRepoPaths, model.Target);

                    return Accepted();
                }
                catch(NotFoundException)
                {
                    return NotFound();
                }
                catch(Exception)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError);
                }                
            }

            return BadRequest();
        }

        [HttpPost("pull")]
        public IActionResult PullBranches([FromBody]BranchesActionModel model)
        {
            if (model.GitRepoPaths!=null && model.GitRepoPaths.Count>0)
            {
                _gitRepoService.PullBranches(model.GitRepoPaths);

                return Accepted();
            }

            return BadRequest();
        }

        [HttpPost("push")]
        public IActionResult PushBranches([FromBody]BranchesActionModel model)
        {
            if (ModelState.IsValid)
            {
                _gitRepoService.PushBranches(model.GitRepoPaths, model.Target);

                return Accepted();
            }

            return BadRequest();
        }

        [HttpPost("create")]
        public IActionResult CreateBranches([FromBody]BranchesActionModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _gitRepoService.CreateBranches(model.GitRepoPaths, model.Target);
                    return Accepted();
                }
                catch (NameConflictException)
                {
                    return Conflict();
                }
                catch(Exception)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError);
                }
            }

            return BadRequest();
        }
    }
}
