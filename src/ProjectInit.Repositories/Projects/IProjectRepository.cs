using ProjectInit.Core.Entities.Projects;
using ProjectInit.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Repositories.Projects
{
    public interface IProjectRepository : IRepository<Project, Guid>
    {

    }
}
