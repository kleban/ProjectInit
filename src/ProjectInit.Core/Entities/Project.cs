using ProjectInit.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public User? Teacher { get; set; }

        [ForeignKey(nameof(Teacher))]
        public string TeacherId { get; set; }
        public virtual ICollection<User>? Students { get; set;} = new HashSet<User>();
    }
}
