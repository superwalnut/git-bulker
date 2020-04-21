﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Gitbulker.Model.Interfaces;

namespace Gitbulker.Model.Entities
{
    public class Project : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Root { get; set; }

        public string BranchingStrategy { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
