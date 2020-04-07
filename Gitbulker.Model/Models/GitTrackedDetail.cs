using System;
namespace Gitbulker.Model.Models
{
    public class GitTrackedDetail
    {
        public string CanonicalName { get; set; }
        public string UpstreamBranchCanonicalName { get; set; }
        public int? AheadBy { get; set; }
        public int? BehindBy { get; set; }       
    }
}
