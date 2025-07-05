using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Repository.Services;
using TaskManager.Repository.Shared;
using TaskManager.ViewModel;
using TaskManager.ViewModels;

namespace TaskManager.Repository
{
   public class ApplicationUserRepository:IApplicationUser
    {
        private ApplicationDbContext _dbContext;
        private UserManager<ApplicationUser> _userManager;

        public ApplicationUserRepository(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManage)
        {
            _dbContext = dbContext;
            _userManager = userManage;
        }
        public async Task <List<ApplicationUserVm>> Get()
        {
            try
            {
                List<ApplicationUserVm> reslist = new List<ApplicationUserVm>();
                var list = _dbContext.ApplicationUsers.ToList();
                foreach (var item in list)
                {
                    reslist.Add(new ApplicationUserVm
                    {
                        Id = item.Id,
                        Address = item.Address,
                        Email = item.Email,
                        FullName = item.FullName,
                        PhoneNumber = item.PhoneNumber,
                        UserName = item.UserName,
                    });
                }
                return reslist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<bool> AddUser(ApplicationUserVm user)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            ApplicationUser dbuser = new ApplicationUser
            {
                Address = user.Address,
                Email = user.Email,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                PasswordHash = hasher.HashPassword(null, user.Password)
            };
            var res = await _userManager.CreateAsync(dbuser, user.Password);
            

            return res.Succeeded;
        }
        
        public async Task<bool> Update(ApplicationUserVm applicationUser)
        {
            try
            {
                var result = _dbContext.ApplicationUsers.Find(applicationUser.Id);

                if (result != null)
                {
                    result.FullName = applicationUser.FullName;
                    result.PhoneNumber = applicationUser.PhoneNumber;
                    result.Address = applicationUser.Address;
                    result.Email = applicationUser.Email;

                    _dbContext.Entry(result).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public string Delete(string Id)
        {
            try
            {
                bool flag = false;
                var tas = _dbContext.ApplicationUsers.Where(e => e.Id == Id).FirstOrDefault();

                if (tas != null)
                {
                    _dbContext.ApplicationUsers.Remove(tas);
                    var v = _dbContext.SaveChanges();
                    flag = v < 1 ? false : true;
                    return "Saved successfully";
                }
                else
                {
                    return "Not Found";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<bool> ChangePassword(string Id, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                return false;
            }

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);

            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
