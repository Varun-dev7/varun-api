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
using TaskManager.ViewModels.Results;

namespace TaskManager.Repository
{
    public class TaskMana : ITaskManager
    {
        private ApplicationDbContext _context;
        public TaskMana(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<RTaskManagerList> Get()
        {
            RTaskManagerList res = new RTaskManagerList();
            try
            {
                List<TaskManagerVm> reslist = new List<TaskManagerVm>();
                var list = _context.taskManagers.ToList();
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        reslist.Add(new TaskManagerVm
                        {
                            Id = item.Id,
                            Title = item.Title,
                            Desciption = item.Desciption,
                            IsCompleted = item.IsCompleted,
                        });
                        res.Data = reslist;
                        res.Result = new ApiResult { Success = true, Code = EMessageCode.Ok, Message = "Succeded" };
                    }
                }
                else
                {
                    res.Data = null;
                    res.Result = new ApiResult { Success = false, Code = EMessageCode.NotFound, Message = "No data found" };
                }
            }
            catch (Exception ex)
            {
                res.Data = null;
                res.Result = new ApiResult { Success = false, Code = EMessageCode.InternalServerError, Message = ex.Message };
            }
            return res;
        }
        public async Task<RTaskManagerList> Gett(EBool status)
        {
            RTaskManagerList res = new RTaskManagerList();
            try
            {
                List<TaskManagerVm> reslist = new List<TaskManagerVm>();
                var list = _context.taskManagers.Where(e => e.IsCompleted == status).ToList();

                if (list != null)
                {
                    foreach (var item in list)
                    {
                        reslist.Add(new TaskManagerVm
                        {
                            Id = item.Id,
                            Title = item.Title,
                            Desciption = item.Desciption,
                            IsCompleted = item.IsCompleted,
                        });
                        res.Data = reslist;
                        res.Result = new ApiResult { Success = true, Code = EMessageCode.Ok, Message = "Succeded" };
                    }
                }
                else
                {
                    res.Data = null;
                    res.Result = new ApiResult { Success = false, Code = EMessageCode.NotFound, Message = "No data found" };
                }
            }
            catch (Exception ex)
            {
                res.Data = null;
                res.Result = new ApiResult { Success = false, Code = EMessageCode.InternalServerError, Message = ex.Message };
            }
            return res;
        }
        public async Task<RTaskManager> Add(TaskManagerVm task)
        {
            RTaskManager data = new RTaskManager();
            try
            {
                TaskM dbtask = new TaskM()
                {
                    Id = task.Id,
                    Title = task.Title,
                    Desciption = task.Desciption,
                    IsCompleted = task.IsCompleted,
                };
                _context.taskManagers.Add(dbtask);
                var result = _context.SaveChanges();

                if (result > 0)
                {
                    task.Id = task.Id;
                    data.Data = task;
                    data.Result = new ApiResult { Success = true, Code = EMessageCode.Ok, Message = "Task added successfully" };
                }
                else
                {
                    data.Data = null;
                    data.Result = new ApiResult { Success = false, Code = EMessageCode.BadRequest, Message = "Failed to add task" };
                }
            }
            catch (Exception ex)
            {
                data.Data = null;
                data.Result = new ApiResult { Success = false, Code = EMessageCode.InternalServerError, Message = ex.Message };
            }
            return data;
        }
        public async Task<ApiResult> Update(TaskManagerVm task)
        {
            ApiResult data = new ApiResult();
            try
            {
                var result = _context.taskManagers.Find(task.Id);

                if (result != null && task.Id == result.Id)
                {
                    result.Id = task.Id;
                    result.Title = task.Title;
                    result.Desciption = task.Desciption;
                    result.IsCompleted = task.IsCompleted;

                    _context.Entry(result).State = EntityState.Modified;
                    var v = _context.SaveChanges();

                    if (v > 0)
                    {
                        data = new ApiResult { Success = true, Code = EMessageCode.Ok, Message = "Task Updated Successfully" };
                    }
                    else
                    {
                        data = new ApiResult { Success = false, Code = EMessageCode.BadRequest, Message = "Failed" };
                    }
                }
                else
                {
                    data = new ApiResult { Success = false, Code = EMessageCode.NotFound, Message = "Task not found" };
                }
            }
            catch (Exception ex)
            {
                data = new ApiResult { Success = false, Code = EMessageCode.InternalServerError, Message = ex.Message };
            }
            return data;
        }
        public async Task<ApiResult> Delete(int Id)
        {
            ApiResult data = new ApiResult();
            try
            {
                var result = _context.taskManagers.Find(Id);

                if (result != null)
                {
                    _context.taskManagers.Remove(result);
                    var v = _context.SaveChanges();

                    if (v > 0)
                    {
                        data = new ApiResult { Success = true, Code = EMessageCode.Ok, Message = "Task Deleted Successfully" };
                    }
                    else
                    {
                        data = new ApiResult { Success = false, Code = EMessageCode.BadRequest, Message = "Failed to delete task" };
                    }
                }
                else
                {
                    data = new ApiResult { Success = false, Code = EMessageCode.NotFound, Message = "Task not found" };
                }
            }
            catch (Exception ex)
            {
                data = new ApiResult { Success = false, Code = EMessageCode.InternalServerError, Message = ex.Message };
            }
            return data;
        }
    }
}
