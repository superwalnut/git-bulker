using System;
using System.Collections.Generic;
using System.IO;
using Gitbulker.Model.Models;
using Gitbulker.Service.Interfaces;
using LibGit2Sharp;
using System.Linq;
using Gitbulker.Model.Extensions;
using Gitbulker.Model.Entities;

namespace Gitbulker.Service.Services
{
    public class DiscoverService : IDiscoverService
    {
        public DiscoverService()
        {

        }

        public List<GitRepo> DiscoverRepositories(Project project)
        {
            List<GitRepo> items = new List<GitRepo>();

            if (!Directory.Exists(project.Root))
                throw new NotFoundException($"Project is not found at {project.Root}");

            DirectoryInfo root = new DirectoryInfo(project.Root);
            var rootRepo = GetGitRepository(root, project.MainBranch);
            if (rootRepo != null)
                items.Add(rootRepo);
            else
            {                
                var dirs = root.GetDirectories(".git", SearchOption.AllDirectories);
                foreach (var d in dirs)
                {
                    var parent = d.Parent;
                    if (Repository.IsValid(parent.FullName))
                    {
                        var repo = GetGitRepository(parent, project.MainBranch);
                        if (repo != null)
                            items.Add(repo);
                    }
                }
            }

            return items;
        }

        private GitRepo  GetGitRepository(DirectoryInfo dir, string mainBranch = "master")
        {
            if (!Repository.IsValid(dir.FullName))
                return null;

            try
            {
                using (var repo = new Repository(dir.FullName))
                {
                    var repoId = new MongoDB.Bson.ObjectId();
                    var commit = repo.GetLastCommit();
                    var trackedDetail = repo.GetTrackedDetail();
                    var branch = repo.GetMainBranch(repoId, mainBranch);
                    var status = repo.RetrieveStatus();

                    GitRepo gitRepo = new GitRepo
                    {
                        Id = repoId,
                        Name = dir.Name,
                        Path = dir.FullName,
                        CanonicalName = repo.Head.CanonicalName,
                        FriendlyName = repo.Head.FriendlyName,
                        IsTracking = repo.Head.IsTracking,
                        IsRemote = repo.Head.IsRemote,
                        LocalCommitCount = repo.Commits.Count(),
                        LocalLastCommitTime = commit.When,
                        LocalLastCommitter = commit.CommitterName,
                        TrackedRemoteBranch = trackedDetail?.CanonicalName,
                        AheadBy = trackedDetail?.AheadBy,
                        BehindBy = trackedDetail?.BehindBy,
                        MainBranchCanonicalName = branch.CanonicalName,
                        MainBranchFriendlyName = branch.FriendlyName,
                        ParentPath = dir.Parent.FullName,
                        HasPendingChanges = status.IsDirty,
                        PendingChangesCount = status.Count(x => x.State != FileStatus.Ignored)
                    };

                    return gitRepo;
                }
            }
            catch(Exception ex)
            {
                var dirr = dir;
                throw ex;
            }            
        }
    }
}
