using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Gitbulker.Model.Interfaces;

namespace Gitbulker.Model.Entities
{
    public class TagItem : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Path { get; set; }

        public string Name { get; set; }

        public string ParentPath { get; set; }

        public string ParentName { get; set; }

        public DateTime Created { get; set; }

        public Tag Tag { get; set; }
    }
}
