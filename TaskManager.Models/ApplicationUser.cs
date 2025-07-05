using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TaskManager.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [RegularExpression(@"[a-zA-Z-_ ]+$", ErrorMessage = "Invalid Name")]
        [Column(TypeName = "NVARCHAR(35)")]
        public string FullName { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        public string? Address { get; set; }
    }
}

