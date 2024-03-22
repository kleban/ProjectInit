using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Core.Entities
{
    public class StudentsProject : IEntity<int>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public Project? Project { get; set; }

        [ForeignKey(nameof(Project))]
        public Guid ProjectId { get; set; }
        public virtual ICollection<User> Students { get; set; } = new HashSet<User>();
    }
}
