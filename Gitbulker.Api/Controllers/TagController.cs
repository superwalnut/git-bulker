using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Gitbulker.Api.Models;
using Gitbulker.Model.Entities;
using Gitbulker.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gitbulker.Api.Controllers
{
    [Route("api/[controller]")]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody]TagModel model)
        {
            if(ModelState.IsValid)
            {
                Tag tag = null;
                if(model.Id.HasValue)
                {
                    // append to existing tag
                    tag = await _tagService.GetById(model.Id.Value);
                }
                else
                {
                    tag = new Tag
                    {
                        Name = model.Name,
                        Created = DateTime.Now,
                        ProjectId = model.ProjectId
                    };
                }

                var tagItems = new List<TagItem>();
                foreach(var item in model.Paths)
                {
                    DirectoryInfo info = new DirectoryInfo(item);
                    if(!info.Exists)
                    {
                        return BadRequest();
                    }

                    var tagItem = new TagItem
                    {
                        Name = info.Name,
                        Path = info.FullName,
                        ParentName = info.Parent?.Name,
                        ParentPath = info.Parent?.FullName,
                    };

                    tagItems.Add(tagItem);
                }

                tag.TagItems = tagItems;

                await _tagService.Save(tag);

                return Accepted();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tagService.Delete(id);
            return Accepted();
        }

        [HttpGet("{id}")]
        public async Task<Tag> GetById(int id)
        {
            var tag = await _tagService.GetById(id);
            return tag;
        }

        [HttpGet("project/{id}")]
        public async Task<List<Tag>> GetByProjectIds(int id)
        {
            var tags = await _tagService.GetAllByProjectId(id);
            return tags;
        }

        [HttpPost("tagitem/delete")]
        public async Task<IActionResult> DeleteByTagItemIds([FromBody]List<int> ids)
        {
            await _tagService.DeleteByTagItemIds(ids);
            return Accepted();
        }
    }
}
