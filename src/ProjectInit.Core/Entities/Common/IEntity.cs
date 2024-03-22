using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Core.Entities.Common
{
    public interface IEntity<T>
    {
        [Key]
        T Id { get; set; }
    }
}
