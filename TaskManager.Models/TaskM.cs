using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ViewModels.Enum;

namespace TaskManager.Model
{
    public class TaskM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desciption { get; set; }
        public EBool IsCompleted { get; set; }
    }
}
