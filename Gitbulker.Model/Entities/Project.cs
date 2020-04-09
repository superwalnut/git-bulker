using System;
using MongoDB.Bson;

namespace Gitbulker.Model.Entities
{
    public class Project
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string Root { get; set; }

        public string MainBranch { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
    }
}
