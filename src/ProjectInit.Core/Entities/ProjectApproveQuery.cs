using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Core.Entities
{
    public class ProjectApproveQuery : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? TeacherComment { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; }
        public string? StudentComment { get; set; }
        public ProjectItem? ProjectItem { get; set; }

        [ForeignKey(nameof(ProjectItem))]
        public Guid ProjectItemId { get; set; }

        //public ProjectItemStatus? Status { get; set; }

        //[ForeignKey(nameof(Status))]
       // public int StatusId { get; set; } = 1;

    }
}
