using Microsoft.EntityFrameworkCore;
using ProjectInit.Core.Context;
using ProjectInit.Core.Entities.Projects;
using ProjectInit.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Repositories.Projects
{
    public class ProjectRepository : Repository<Project, Guid>, IProjectRepository    {
        public ProjectRepository(ProjectContext ctx) : base(ctx) { }

        public async override Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _ctx.Projects
                .Include(x => x.Teacher)
                .Include(x => x.Items)
                .Include(x => x.Links).ToListAsync();
        }
    }
}
