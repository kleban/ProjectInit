using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Core.Entities
{
    public class ProjectAccessQuery : IEntity<Guid>
    {
        public Guid Id { get ; set; } = Guid.NewGuid();
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public User Student { get; set; }

        [ForeignKey(nameof(Student))]
        public Guid UserId { get; set; }

        public ProjectItem ProjectItem { get; set; }

        [ForeignKey(nameof(ProjectItem))]
        public Guid ProjectItemId { get; set; }
    }
}
