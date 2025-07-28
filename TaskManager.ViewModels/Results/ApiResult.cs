using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ViewModels.Enum;

namespace TaskManager.ViewModels.Results
{
    public class ApiResult
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public EMessageCode Code { get; set; }
        public string Message { get; set; }
    }
}
