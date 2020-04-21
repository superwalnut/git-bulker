using System;
using System.Collections;
using System.Collections.Generic;
using Gitbulker.Model.Models;

namespace Gitbulker.Model.Entities
{
    public class GitRepo
    {
        public string Path { get; set; }

        public string Name { get; set; }

        public string ParentPath { get; set; }

        public string ParentName { get; set; }
        
        public string CurrentHeadCanonicalName { get; set; }

        public string CurrentHeadFriendlyName { get; set; }

        public bool IsTracking { get; set; }
        public bool IsRemote { get; set; }

        public int LocalCommitCount { get; set; }
        public DateTime? LocalLastCommitTime { get; set; }
        public string LocalLastCommitter { get; set; }

        public string TrackedRemoteCanonicalName { get; set; }
        public int? AheadBy { get; set; }
        public int? BehindBy { get; set; }

        public string DevelopCanonicalName { get; set; }

        public string DevelopFriendlyName { get; set; }

        public string MasterCanonicalName { get; set; }

        public string MasterFriendlyName { get; set; }

        public bool HasPendingChanges { get; set; }

        public int PendingChangesCount { get; set; }

        public TrackedDetail TrackedDetail
        {
            get
            {
                if (AheadBy == 0 && BehindBy == 0)
                    return TrackedDetail.Same;

                if (AheadBy > 0)
                    return TrackedDetail.Ahead;

                if (BehindBy > 0)
                    return TrackedDetail.Behind;

                return TrackedDetail.Unknown;
            }
        }
    }
}
