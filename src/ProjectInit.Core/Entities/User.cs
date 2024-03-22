using Microsoft.AspNetCore.Identity;
using ProjectInit.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Core.Entities
{
    public class User : IdentityUser, IEntity<string>
    {
        public string? Name { get; set; }
        public ICollection<Project>? TeacherProjects { get; set; }
        public ICollection<Project>? StudentProjects { get; set; }
    }
}
