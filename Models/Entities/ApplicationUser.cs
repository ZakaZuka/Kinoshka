using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Kinoshka.Models.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            OwnedProjects = new List<Project>();
            OwnedJobs = new List<Job>();
            ParticipateJobs = new List<Job>();
        }

        public string Name { get; set; }
        public string Lastname { get; set; }
        public string FullName => $"{Lastname} {Name}";
        public DateTime? Birthdate { get; set; }
        public virtual ICollection<Project> OwnedProjects { get; set; }
        public virtual ICollection<Job> OwnedJobs { get; set; }
        public virtual ICollection<Job> ParticipateJobs { get; set; }

    }
}