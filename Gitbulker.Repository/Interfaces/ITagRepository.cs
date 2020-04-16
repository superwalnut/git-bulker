using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gitbulker.Model.Entities;

namespace Gitbulker.Repository.Interfaces
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<List<Tag>> GetAllByProjectId(int id);

        Task DeleteByTagItemIds(List<int> ids);
    }
}
