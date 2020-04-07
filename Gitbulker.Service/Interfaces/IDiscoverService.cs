using System;
using System.Collections.Generic;
using Gitbulker.Model.Models;

namespace Gitbulker.Service.Interfaces
{
    public interface IDiscoverService
    {
        List<GitRepository> DiscoverRepositories(Project project);
    }
}
