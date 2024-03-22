using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectInit.Core.Entities;
using System.Reflection.Emit;

namespace ProjectInit.Core.Context
{
    public class ProjectContext : IdentityDbContext<User>
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects => Set<Project>();   

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasMany<Project>(p=> p.StudentProjects)
                .WithMany(p => p.Students);

            builder
               .Entity<User>()
               .HasMany<Project>(p => p.TeacherProjects)
               .WithOne(p => p.Teacher);

            base.OnModelCreating(builder);
        }       
    }
}
