using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kinoshka.Models.Entities
{
    public class Job : BaseEntity<Guid>
    {
        public Job()
        {
            Attachments = new List<Attachment>();
            Responsibles = new List<ApplicationUser>();
            Comments = new List<Comment>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public Guid ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))] public virtual Project Project { get; set; }

        public int StatusId { get; set; }

        [ForeignKey(nameof(StatusId))] public virtual JobStatus Status { get; set; }

        public Guid AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))] public virtual ApplicationUser Author { get; set; }

        public DateTime Deadline { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }

        public virtual ICollection<ApplicationUser> Responsibles { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}