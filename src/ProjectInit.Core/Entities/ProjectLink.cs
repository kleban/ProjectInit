using ProjectInit.Core.Entities.Common;
using ProjectInit.Core.Entities.Projects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Core.Entities
{
    public class ProjectLink : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Url { get; set; }
        
        public Project? Project { get; set; }
        [ForeignKey(nameof(Project))]
        public Guid? ProjectId { get; set; }
    }
}
