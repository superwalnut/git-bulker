using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gitbulker.Model.Entities;
using Gitbulker.Repository.Interfaces;

namespace Gitbulker.Repository.Repositories
{
    public class ProjectRepository : BaseRepository<Project, GitbulkerDbContext>, IProjectRepository
    {
        public ProjectRepository(GitbulkerDbContext context) : base(context)
        {
        }

        
    }
}
