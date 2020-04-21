using System;
using System.Collections.Generic;
using Gitbulker.Model.Models;
using MongoDB.Bson;

namespace Gitbulker.Model.Entities
{
    public class Tag
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public ObjectId ProjectId { get; set; }

        public List<GitBranch> Repositories { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
    }
}
