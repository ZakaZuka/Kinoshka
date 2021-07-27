using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kinoshka.Models.Entities
{
    public class Attachment : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public byte[] Source { get; set; }
        public Guid JobId { get; set; }

        [ForeignKey(nameof(JobId))] public virtual Job Job { get; set; }
    }
}