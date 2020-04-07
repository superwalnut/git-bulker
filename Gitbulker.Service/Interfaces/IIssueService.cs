using System;
using Gitbulker.Model.Models;

namespace Gitbulker.Service.Interfaces
{
    public interface IIssueService
    {
        void Save(Issue issue);
    }
}
