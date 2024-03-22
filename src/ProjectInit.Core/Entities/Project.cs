using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Core.Entities
{
    public class Project : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? CourseName { get; set; }
        public string? ProjectName { get; set; }        
        public User? Teacher { get; set; }

        [ForeignKey(nameof(Teacher))]
        public string TeacherId { get; set; }
        public virtual ICollection<StudentsProject> StudentsProjects { get; set; } = new HashSet<StudentsProject>();
    }
}
