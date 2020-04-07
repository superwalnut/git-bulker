using System;
using Gitbulker.Model.Models;

namespace Gitbulker.Service.Interfaces
{
    public interface IStoreService
    {
        void SaveTag(Tag tag);

        void SaveProject(Project project);

        Project LoadProject(string id);

        void CreateProject(string name);
    }
}
