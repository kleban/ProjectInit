using ProjectInit.Core.Entities;
using ProjectInit.Repositories.Common;
using ProjectInit.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Repositories.Users
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        public Task<IEnumerable<UserListItemModel>> GetAllWithRolesAsync();
    }
}
