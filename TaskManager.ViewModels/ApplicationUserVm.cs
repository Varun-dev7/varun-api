using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ViewModels
{
    public class ApplicationUserVm
    {
        public string Id { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [RegularExpression(@"[0-9]+$", ErrorMessage = "Mobile no should only numbers")]
        [StringLength(10, MinimumLength = 10)]
        public string? PhoneNumber { get; set; }
        //[RegularExpression(@"[a-z0-9-_]+$", ErrorMessage = "Invalid User name (a to z _ - )")]
        public string? UserName { get; set; }
        public string Password { get; set; }
        [RegularExpression(@"[a-zA-Z-_ ]+$", ErrorMessage = "Invalid Name")]
        public string FullName { get; set; }
        public string? Address { get; set; }
    }
}
