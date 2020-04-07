using System;
using Gitbulker.Model.Models;
using Gitbulker.Service.Interfaces;

namespace Gitbulker.Service.Services
{
    public class TagService : ITagService
    {
        private readonly IStoreService _storeService;

        public TagService(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public void Save(Tag tag)
        {
            _storeService.SaveTag(tag);
        }
    }
}
