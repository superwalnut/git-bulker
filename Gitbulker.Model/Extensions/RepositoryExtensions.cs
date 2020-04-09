using System;
using System.Linq;
using Gitbulker.Model.Models;
using LibGit2Sharp;

namespace Gitbulker.Model.Extensions
{
    public static class RepositoryExtensions
    {
        public static GitCommit GetLastCommit(this Repository repo)
        {
            var lastCommit = repo.Commits.OrderByDescending(x => x.Committer.When).FirstOrDefault();
            return new GitCommit
            {
                When = lastCommit?.Committer.When.LocalDateTime,
                CommitterName = lastCommit?.Committer.Name,
                CommitterEmail = lastCommit?.Committer.Email
            };
        }

        public static GitTrackedDetail GetTrackedDetail(this Repository repo)
        {
            if (repo.Head.IsTracking)
            {
                return new GitTrackedDetail
                {
                    CanonicalName = repo.Head.TrackedBranch?.CanonicalName,
                    UpstreamBranchCanonicalName = repo.Head.TrackedBranch?.UpstreamBranchCanonicalName,
                    AheadBy = repo.Head.TrackingDetails?.AheadBy,
                    BehindBy = repo.Head.TrackingDetails?.BehindBy
                };
            }
            
            return null;
        }

        public static GitBranch GetMainBranch(this Repository repo, MongoDB.Bson.ObjectId id, string mainBranch)
        {
            if (!string.IsNullOrEmpty(mainBranch))
            {
                var main = repo.Refs.FirstOrDefault(x => x.IsLocalBranch && x.CanonicalName == $"refs/heads/{mainBranch.ToLower()}");
                return new GitBranch
                {
                    GitRepoId = id,
                    CanonicalName = main?.CanonicalName,
                    FriendlyName = mainBranch.ToLower()
                };
            }

            return null;
        }
    }
}
