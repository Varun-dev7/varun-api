using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Model;
using TaskManager.ViewModel;
using TaskManager.ViewModels.Enum;
using TaskManager.ViewModels.Results;

namespace TaskManager.Repository.Services
{
    public interface ITaskManager
    {
        public Task<RTaskManagerList> Get();
        public Task<RTaskManagerList> Gett(EBool status);
        public Task<RTaskManager> Add(TaskManagerVm task);
        public Task<ApiResult> Update(TaskManagerVm task);
        public Task<ApiResult> Delete(int Id);
    }
}
