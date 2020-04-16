using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Gitbulker.Model.Interfaces;
using Gitbulker.Model.Models;

namespace Gitbulker.Model.Entities
{
    public class Tag : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }

        public ICollection<TagItem> TagItems { get; set; }
    }
}
