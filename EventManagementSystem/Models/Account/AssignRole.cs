using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models.Account
{
    public class AssignRole
    {
        [Key,ForeignKey("Employee")]
        [Required(ErrorMessage ="Enter Employee Id")]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Enter Role")]
        public string Role { get; set; }
        [Required(ErrorMessage = "Enter Employee Current Role")]
        public string CurrentRole { get; set; }
        public virtual Employee Employee { get; set; }
    }
}