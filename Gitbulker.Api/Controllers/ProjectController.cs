using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Gitbulker.Api.Models;
using Gitbulker.Model.Entities;
using Gitbulker.Service.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Gitbulker.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody]ProjectModel model)
        {
            if(ModelState.IsValid)
            {
                IMapper imap = AutoMapperConfiguration.GetConfig().CreateMapper();
                var project = imap.Map<ProjectModel, Project>(model);

                var savedProject = await _projectService.Save(project);

                return Accepted(savedProject);
            }

            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var project = await _projectService.GetById(id);

            if(project!=null)
                return Ok(project);

            return NotFound();
        }

        [HttpGet("list")]
        public async Task<List<Project>> GetAll()
        {
            var projects = await _projectService.GetAll();
            return projects;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _projectService.Delete(id);
            return Accepted();
        }
    }
}
