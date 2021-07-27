using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kinoshka.Models.Entities
{
    public class Comment : BaseEntity<Guid>
    {
        public Guid AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public Guid JobId { get; set; }

        [ForeignKey(nameof(JobId))] public virtual Job Job { get; set; }

        public string Text { get; set; }
    }
}