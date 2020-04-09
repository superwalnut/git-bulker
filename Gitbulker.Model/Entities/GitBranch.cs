using System;
using MongoDB.Bson;

namespace Gitbulker.Model.Models
{
    public class GitBranch
    {
        public ObjectId GitRepoId { get; set; }
        public string CanonicalName { get; set; }
        public string FriendlyName { get; set; }
    }
}
