﻿using Microsoft.AspNetCore.Identity;
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
        Task<IEnumerable<UserListItemModel>> GetAllWithRolesAsync();
        Task<User> CreateWithPasswordAsync(UserCreateModel model);
        Task<IEnumerable<IdentityRole<Guid>>> GetRolesAsync();
        Task<UserListItemModel> GetOneWithRolesAsync(Guid id);
        Task UpdateUserAsync(UserListItemModel model, string[] roles);

        Task<bool> CheckUser(Guid id);
        Task DeleteUser(Guid id);
    }
}
