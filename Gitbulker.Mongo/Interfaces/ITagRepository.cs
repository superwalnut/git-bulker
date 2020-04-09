using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gitbulker.Mongo.Interfaces
{
    public interface ITagRepository
    {
        Task<Model.Entities.Tag> GetTagById(string id);
        Task<Model.Entities.Tag> GetTagByName(string name);
        Task<List<Model.Entities.Tag>> GetAll();
        Task SaveTag(Model.Entities.Tag tag);
    }
}
