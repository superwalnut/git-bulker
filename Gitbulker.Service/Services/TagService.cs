using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gitbulker.Model.Entities;
using Gitbulker.Model.Models;
using Gitbulker.Repository.Interfaces;
using Gitbulker.Service.Interfaces;

namespace Gitbulker.Service.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<Tag> Save(Tag tag)
        {
            var newTag = await _tagRepository.Add(tag);
            return newTag;
        }

        public async Task<Tag> GetById(int id)
        {
            var tag = await _tagRepository.Get(id);
            return tag;
        }

        public async Task<List<Tag>> GetAllByProjectId(int id)
        {
            var tags = await _tagRepository.GetAllByProjectId(id);
            return tags;
        }

        public async Task<Tag> Delete(int id)
        {
            var tag = await _tagRepository.Delete(id);
            return tag;
        }

        public async Task DeleteByTagItemIds(List<int> ids)
        {
            await _tagRepository.DeleteByTagItemIds(ids);
        }
    }
}
