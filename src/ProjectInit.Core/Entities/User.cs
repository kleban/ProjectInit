using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Core.Entities
{
    public class User : IdentityUser<Guid>, IEntity<Guid>
    {
        public string? FullName { get; set; }
        public virtual ICollection<Project> TeacherProjects { get; set; } = new HashSet<Project>();
        public virtual ICollection<ProjectItem> StudentProjects { get; set; } = new HashSet<ProjectItem>();
    }
}
