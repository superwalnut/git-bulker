using System;
using Gitbulker.Model.Entities;
using Gitbulker.Model.Models;
using Gitbulker.Mongo.Interfaces;
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

        public Tag Save(Tag tag)
        {
            _tagRepository.SaveTag(tag);
            return tag;
        }
    }
}
