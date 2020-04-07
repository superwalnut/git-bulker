using System;
namespace Gitbulker.Model.Models
{
    public class GitCommit
    {
        public string CommitterName { get; set; }
        public string CommitterEmail { get; set; }
        public DateTime? When { get; set; }
    }
}
