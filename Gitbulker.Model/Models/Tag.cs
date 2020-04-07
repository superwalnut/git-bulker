using System;
using System.Collections.Generic;

namespace Gitbulker.Model.Models
{
    public class Tag
    {
        public string Name { get; set; }
        public string ProjectId { get; set; }
        public List<GitBranch> Repositories { get; set; }
    }
}
