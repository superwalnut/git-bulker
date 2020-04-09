using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Gitbulker.Model.Entities;
using Gitbulker.Model.Models;
using MongoDB.Bson;

namespace Gitbulker.Web.Models
{
    public class GitRepoViewModel
    {
        public ObjectId Id { get; set; } //Path = Id

        public string Path { get; set; }

        [DisplayName("Repository")]
        public string Name { get; set; }

        public string ParentPath { get; set; }

        public string CanonicalName { get; set; }

        [DisplayName("Current")]
        public string FriendlyName { get; set; }

        public bool IsTracking { get; set; }

        public bool IsRemote { get; set; }

        [DisplayName("Commits")]
        public int LocalCommitCount { get; set; }

        [DisplayName("Updated")]
        [DisplayFormat(DataFormatString = "{0:g}")]
        public DateTime? LocalLastCommitTime { get; set; }
       
        public string LocalLastCommitter { get; set; }
        
        public string TrackedRemoteBranch { get; set; }

        public int? AheadBy { get; set; }
        public int? BehindBy { get; set; }

        public string MainBranchCanonicalName { get; set; }

        [DisplayName("develop/master")]
        public string MainBranchFriendlyName { get; set; }

        [DisplayName("Changes")]
        public bool HasPendingChanges { get; set; }

        public int PendingChangesCount { get; set; }

        [DisplayName("Status")]
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

        public static void AutoMapped()
        {
           
        }
    }
}
