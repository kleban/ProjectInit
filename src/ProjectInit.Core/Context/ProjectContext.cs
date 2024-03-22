using Microsoft.AspNetCore.Identity;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
           builder
                .Entity<StudentsProject>()
                .HasMany(x => x.Students)
                .WithMany(x=> x.StudentProjects);

            /////////////
            foreach (var foreignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            }

            base.OnModelCreating(builder);
        }

        public DbSet<Project> Projects => Set<Project>();
        public DbSet<StudentsProject> StudentsProjects => Set<StudentsProject>();
    }
}
