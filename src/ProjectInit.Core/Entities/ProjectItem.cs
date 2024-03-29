using ProjectInit.Core.Context;
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
    public class ProjectItem : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public Project? Project { get; set; }

        [ForeignKey(nameof(Project))]
        public Guid ProjectId { get; set; }
        public virtual ICollection<User> Students { get; set; } = new HashSet<User>();
        public DateTime StatusDate { get; set; } = DateTime.Now;
        public ProjectItemStatus Status { get; set; }

        [ForeignKey(nameof(Status))]
        public int StatusId { get; set; } = (int)StatusType.Draft;
        
        public virtual ICollection<ProjectApproveQuery> ApproveQueries { get; set; } = new HashSet<ProjectApproveQuery>();
        public virtual ICollection<ProjectAccessQuery> AccessQueries { get; set; } = new HashSet<ProjectAccessQuery>();
    }
}
