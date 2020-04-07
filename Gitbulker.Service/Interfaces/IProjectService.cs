using System;
using Gitbulker.Model.Models;

namespace Gitbulker.Service.Interfaces
{
    public interface IProjectService
    {
        Project Create(string name, string root, string mainBranch);

        Project Load(string id);
    }
}
