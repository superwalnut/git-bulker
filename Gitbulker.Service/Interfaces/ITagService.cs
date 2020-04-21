﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gitbulker.Model.Entities;

namespace Gitbulker.Service.Interfaces
{
    public interface ITagService
    {
        Task<Tag> Save(Tag tag);

        Task<Tag> GetById(int id);

        Task<List<Tag>> GetAllByProjectId(int id);

        Task<Tag> Delete(int id);

        Task DeleteByTagItemIds(List<int> ids);
    }
}
