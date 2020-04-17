using DAL.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ProjectManagementContext : IdentityDbContext
    {
        public ProjectManagementContext(DbContextOptions<ProjectManagementContext> options) 
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
