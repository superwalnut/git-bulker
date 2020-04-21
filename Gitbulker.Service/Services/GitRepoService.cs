using System;
using Gitbulker.Service.Interfaces;
using System.Linq;
using System.Collections.Generic;
using Serilog;
using LibGit2Sharp;

namespace Gitbulker.Service.Services
{
    public class GitRepoService : IGitRepoService
    {
        private const string GitRepoPrefix = "refs/heads/";
        private readonly ILogger _logger;

        public GitRepoService(ILogger logger)
        {
            _logger = logger;
        }

        public void SwitchBranches(List<string> gitRepoPaths, string target)
        {
            foreach(var path in gitRepoPaths)
            {
                SwitchBranch(path, target);
            }
        }

        public void CreateBranches(List<string> gitRepoPaths, string target)
        {
            foreach(var path in gitRepoPaths)
            {
                CreateBranch(path, target);
            }
        }

        public void PushBranches(List<string> gitRepoPaths, string target)
        {
            foreach (var path in gitRepoPaths)
            {
                PushBranch(path, target);
            }
        }

        public void PullBranches(List<string> gitRepoPaths)
        {
            foreach (var path in gitRepoPaths)
            {
                PullBranch(path);
            }
        }

        //private void CommitBranch(string gitRepoPath)
        //{
        //    using (var repo = new LibGit2Sharp.Repository(gitRepoPath))
        //    {
        //        RepositoryStatus status = repo.RetrieveStatus();

        //        if (status.IsDirty)
        //        {
        //            // Stage all files = git add --all .
        //            Commands.Stage(repo, "*");
        //            // Commit changes

        //            // Create the committer's signature and commit
        //Configuration config = repo.Config;
        //Signature author = config.BuildSignature(DateTimeOffset.Now);

        //            // Commit to the repository
        //            Commit commit = repo.Commit("Here's a commit i made!", author, committer);
        //        }                
        //    }
        //}

        private void PullBranch(string gitRepoPath)
        {
            using (var repo = new LibGit2Sharp.Repository(gitRepoPath))
            {                
                PullOptions pullOptions = new PullOptions()
                {
                    FetchOptions = new FetchOptions(),
                };

                Configuration config = repo.Config;
                Signature author = config.BuildSignature(DateTimeOffset.Now);

                Commands.Fetch(repo, repo.Head.RemoteName, new string[0], pullOptions.FetchOptions, null);
            }
        }

        private void PushBranch(string gitRepoPath, string target)
        {
            using (var repo = new LibGit2Sharp.Repository(gitRepoPath))
            {
                var remote = repo.Network.Remotes["origin"];
                var options = new PushOptions();
                    
                var pushRefSpec = $"{GitRepoPrefix}{target}";
                repo.Network.Push(remote, pushRefSpec);
            }
        }

        private void CreateBranch(string gitRepoPath, string target)
        {
            using (var repo = new LibGit2Sharp.Repository(gitRepoPath))
            {
                if(repo.Branches.Any(x => x.CanonicalName == $"{GitRepoPrefix}{target}"))
                {
                    throw new NameConflictException("branch is already exist");
                }

                repo.CreateBranch(target);
            }
        }

        private void SwitchBranch(string gitRepoPath, string target)
        {
            using (var repo = new LibGit2Sharp.Repository(gitRepoPath))
            {
                var selected = repo.Branches.FirstOrDefault(x => x.CanonicalName == $"{GitRepoPrefix}{target}");

                if (selected == null)
                {
                    throw new NotFoundException("branch is not found");
                }

                Branch branch = Commands.Checkout(repo, selected);
                _logger.Information("check out {branch} for repo:{gitRepoPath}", branch, gitRepoPath);
            }
        }
    }
}
