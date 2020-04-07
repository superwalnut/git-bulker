using System;
namespace Gitbulker.Model.Models
{
    public class GitBranch
    {
        public string GitRepositoryId { get; set; }
        public string CanonicalName { get; set; }
        public string FriendlyName { get; set; }
    }
}
