using System;
using System.Threading;
using System.Threading.Tasks;
using Kinoshka.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Kinoshka.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<JobStatus> Statuses { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public DbSet<Kinoshka.Models.MovieRequest> MovieRequest { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Project>()
                .HasOne(x => x.Author)
                .WithMany(x => x.OwnedProjects)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Project>()
                .HasMany(x => x.Jobs)
                .WithOne(x => x.Project)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Job>()
                .HasOne(x => x.Author)
                .WithMany(x => x.OwnedJobs)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Job>()
                .HasMany(x => x.Responsibles)
                .WithMany(x => x.ParticipateJobs);
            builder.Entity<Job>()
                .HasOne(x => x.Project)
                .WithMany(x => x.Jobs)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Job>()
                .HasMany(x => x.Comments)
                .WithOne(x => x.Job)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
                builder.UseSqlServer("Server=localhost; Database=Cinema; Trusted_Connection=True; Connection Timeout=30;");

            base.OnConfiguring(builder);
        }
    }
}