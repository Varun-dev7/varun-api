using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Model;
using TaskManager.Repository.Services;
using TaskManager.ViewModel;
using TaskManager.ViewModels.Enum;

namespace TaskManager.Repository
{
    public class TaskMana: ITaskManager
    {
        private ApplicationDbContext _context;
        public TaskMana(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<TaskManagerVm> Get()
        {
            try
            {
                List<TaskManagerVm> reslist = new List<TaskManagerVm>();
                var list = _context.taskManagers.ToList();
                foreach(var item in list)
                {
                    reslist.Add(new TaskManagerVm
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Desciption = item.Desciption,
                        IsCompleted = item.IsCompleted,
                    });
                }
                return reslist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<TaskManagerVm> Gett(EBool status)
        {
            try
            {
                List<TaskManagerVm> reslist = new List<TaskManagerVm>();
                var list = _context.taskManagers.Where(e => e.IsCompleted == status).ToList();
                foreach (var item in list)
                {
                    reslist.Add(new TaskManagerVm
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Desciption = item.Desciption,
                        IsCompleted = item.IsCompleted,
                    });
                }
                return reslist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Add(TaskManagerVm user)
        {
            try
            {
                TaskM task = new TaskM
                {
                    Id = user.Id,
                    Title=user.Title,
                    Desciption=user.Desciption,
                    IsCompleted=user.IsCompleted,
                };
                bool flag = false;
                _context.taskManagers.Add(task);

                var x = _context.SaveChanges();
                flag = x < 1 ? false: true;
                return flag;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public string Update(TaskManagerVm user)
        {
            try
            {
                bool flag = false;
                var tas = _context.taskManagers.Where(e => e.Id == user.Id).FirstOrDefault();

                if(tas!=null&& user.Id==tas.Id)
                {
                    tas.Id = user.Id;
                    tas.Title = user.Title;
                    tas.Desciption = user.Desciption;
                    tas.IsCompleted = user.IsCompleted;

                    _context.taskManagers.Update(tas);
                    var v = _context.SaveChanges();
                    flag = v < 1 ? false : true;
                    return "Saved successfully";
                }
                else
                {
                    return "Not Found";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public string Delete(int Id)
        {
            try
            {
                bool flag = false;
                var tas = _context.taskManagers.Where(e => e.Id == Id).FirstOrDefault();

                if (tas != null)
                {
                    _context.taskManagers.Remove(tas);
                    var v = _context.SaveChanges();
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
    }
}
