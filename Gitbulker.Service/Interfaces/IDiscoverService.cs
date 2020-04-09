using System;
using System.Collections.Generic;
using Gitbulker.Model.Entities;
using Gitbulker.Model.Models;

namespace Gitbulker.Service.Interfaces
{
    public interface IDiscoverService
    {
        List<GitRepo> DiscoverRepositories(Project project);
    }
}
