using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gitbulker.Api.Models
{
    public class BranchesActionModel
    {
        [Required]
        public List<string> GitRepoPaths { get; set; }

        [Required]
        public string Target { get; set; }
    }
}
