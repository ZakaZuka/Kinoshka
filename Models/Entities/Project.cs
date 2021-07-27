using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kinoshka.Models.Entities
{
    public class Project : BaseEntity<Guid>
    {
        public Project()
        {
            Jobs = new List<Job>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public Guid AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))] public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}