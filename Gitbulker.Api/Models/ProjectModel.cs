using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace Gitbulker.Api.Models
{
    public class ProjectModel
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Root { get; set; }

        [Required]
        public string BranchingStrategy { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
    }
}
