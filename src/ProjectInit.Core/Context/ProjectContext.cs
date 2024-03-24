using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectInit.Core.Entities;
using System.Reflection.Emit;

namespace ProjectInit.Core.Context
{
    public class ProjectContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           builder
                .Entity<ProjectItem>()
                .HasMany(x => x.Students)
                .WithMany(x=> x.StudentProjects);

            base.OnModelCreating(builder);
        }

        public DbSet<Project> Projects => Set<Project>();
        public DbSet<ProjectItem> ProjectItems => Set<ProjectItem>();
        public DbSet<ProjectItemStatus> ProjectItemStatuses => Set<ProjectItemStatus>();
    }
}
