using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ProjectManagementContext : DbContext
    {
        public ProjectManagementContext(DbContextOptions<ProjectManagementContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProject>()
                .HasKey(up => new { up.ProjectId, up.UserId});

            modelBuilder.Entity<UserProject>()
                        .HasOne(pt => pt.User)
                        .WithMany(p => p.UserProject)
                        .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserProject>()
                        .HasOne(pt => pt.Project)
                        .WithMany(t => t.UserProject)
                        .HasForeignKey(pt => pt.ProjectId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<TaskCategory> TaskCategory { get; set; }
        public DbSet<Task> Task { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectRole> ProjectRole { get; set; }
        public DbSet<OrganizationRole> OrganizationRole { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<UserProject> UserProject { get; set; }
    }
}
