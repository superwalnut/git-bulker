using System;
using System.ComponentModel;
using AutoMapper;
using Gitbulker.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gitbulker.Web.Models
{
    public class ProjectViewModel
    {
        public ProjectViewModel()
        {
            DevelopmentBranches = new[] { "develop", "master" };
        }

        [DisplayName("Project Name")]
        public string Name { get; set; }

        [DisplayName("Project Root")]
        public string Root { get; set; }

        [BindProperty]
        public string DevelopmentBranch { get; set; }

        public string[] DevelopmentBranches { get; set; }

        [DisplayName("Other")]
        public string OtherBranch { get; set; }

    }
}
