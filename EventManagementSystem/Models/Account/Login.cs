using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models.Account
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter Your Email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email Address Not Valid")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Enter Your Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }
}