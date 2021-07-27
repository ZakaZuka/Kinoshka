using System;

namespace Kinoshka.Models.Entities
{
    public abstract class BaseEntity<TKey>
        where TKey : struct
    {
        public TKey Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "admin";
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; } = "moderator";
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; } = null;
        public string DeletedBy { get; set; } = null;
    }
}