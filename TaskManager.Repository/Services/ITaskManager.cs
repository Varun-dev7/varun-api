using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ViewModel;
using TaskManager.ViewModels.Enum;

namespace TaskManager.Repository.Services
{
    public interface ITaskManager
    {
        public List<TaskManagerVm> Get();
        public List<TaskManagerVm> Gett(EBool status);
        public bool Add(TaskManagerVm user);
        public string Update(TaskManagerVm user);
        public string Delete(int Id);
    }
}
