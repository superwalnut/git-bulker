using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gitbulker.Api.Models
{
    public class TagModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public List<string> Paths { get; set; }

        [Required]
        public int ProjectId { get; set; }
    }
}
