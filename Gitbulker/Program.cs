using System;
using LibGit2Sharp;
using System.Linq;
using System.IO;
using Gitbulker.Service.Services;
using Gitbulker.Model.Models;

namespace Gitbulker
{
    class Program
    {
        static void Main(string[] args)
        {
            var projectService = new ProjectService();
            var discoverService = new DiscoverService();

            string projectName = "coronavirusnumberfrontend";

            //projectService.Create(projectName, @"/Users/kevinwang/netcore/coronavirus/frontend", "master");

            var project = projectService.Load(projectName);

            var gitRepositories = discoverService.DiscoverRepositories(project);

            if(gitRepositories!= null && gitRepositories.Count>0)
            {
                foreach (var repo in gitRepositories)
                {
                    Console.WriteLine("-----");
                    Console.WriteLine(repo.Name);
                    Console.WriteLine(repo.Path);
                    Console.WriteLine(repo.FriendlyName);
                    Console.WriteLine($"{repo.LocalCommitCount} commits, last commit by {repo.LocalLastCommitter} at {repo.LocalLastCommitTime?.ToString("yyyy-MM-dd HH:mm")}");
                    Console.Write($"tracking {repo.TrackedBranch}\t");
                    switch(repo.TrackedDetail)
                    {
                        case TrackedDetail.Same:
                            Console.Write($"(-)\n");
                            break;
                        case TrackedDetail.Ahead:
                            Console.Write($"(↑{repo.AheadBy})\n");
                            break;
                        case TrackedDetail.Behind:
                            Console.Write($"(↓{repo.BehindBy})\n");
                            break;
                    }

                    Console.WriteLine(repo.MainBranchCanonicalName);
                    if(repo.CanonicalName != repo.MainBranchCanonicalName)
                    {
                        Console.WriteLine($"It is not {repo.MainBranchFriendlyName}");
                    }

                    Console.WriteLine($"parent is {repo.ParentPath}");

                    Console.WriteLine($" repo is {(repo.HasPendingChanges ? "dirty (" + repo.PendingChangesCount + ")" : "ready")}");
                    
                    Console.WriteLine("**********");
                }

                var groups = gitRepositories.GroupBy(x => x.ParentPath);
                foreach(var g in groups)
                {
                    Console.WriteLine($"group:{g.Key}, count:{g.Count()}");
                }
            }

            Console.WriteLine("finish!");
            Console.ReadLine();
        }
    }
}
