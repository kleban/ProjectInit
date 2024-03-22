using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using ProjectInit.Core.Context;
using ProjectInit.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Repositories
{
    public static class DIRepositories
    {
        public static void AddDbRepositories(this IServiceCollection services,
            string connectionString)
        {           
            services.AddDbContext<ProjectContext>(options =>
                options.UseSqlServer(connectionString));         

            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        }
    }
}
