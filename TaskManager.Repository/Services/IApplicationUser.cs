using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.ViewModels;

namespace TaskManager.Repository.Services
{
    public interface IApplicationUser
    {
        public Task<List<ApplicationUserVm>> Get();
        public Task<bool> AddUser(ApplicationUserVm user);
        public Task<bool> Update(ApplicationUserVm applicationUser);
        public string Delete(string Id);
        public Task<bool> ChangePassword(string Id, string newPassword);

    }
}
