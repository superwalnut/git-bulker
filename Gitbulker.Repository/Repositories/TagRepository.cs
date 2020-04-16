using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gitbulker.Model.Entities;
using Gitbulker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gitbulker.Repository.Repositories
{
    public class TagRepository : BaseRepository<Tag, GitbulkerDbContext>, ITagRepository
    {
        public TagRepository(GitbulkerDbContext context) : base(context)
        {
        }


        public async Task<List<Tag>> GetAllByProjectId(int id)
        {
            var items = await context.Tags.Where(x => x.ProjectId == id).ToListAsync();
            return items;
        }

        public async Task DeleteByTagItemIds(List<int> ids)
        {
            var tagItems = await context.TagItems.Where(x => ids.Contains(x.Id)).ToListAsync();
            if(tagItems!= null)
            {
                foreach(var item in tagItems)
                {
                    context.TagItems.Remove(item);
                }
                
                await context.SaveChangesAsync();
            }
        }
    }
}
