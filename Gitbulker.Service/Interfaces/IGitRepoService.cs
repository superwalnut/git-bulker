using System;
using System.Collections.Generic;
using Gitbulker.Model.Entities;

namespace Gitbulker.Service.Interfaces
{
    public interface IGitRepoService
    {
        void SwitchBranches(List<string> gitRepoPaths, string target);

        void CreateBranches(List<string> gitRepoPaths, string target);

        void PushBranches(List<string> gitRepoPaths, string target);

        void PullBranches(List<string> gitRepoPaths);
    }
}
