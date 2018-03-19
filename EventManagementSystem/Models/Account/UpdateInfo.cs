using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models.Account
{
    public class UpdateInfo
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
       
        public string City { get; set; }
      
       
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email Address Not Valid")]
        public string Email { get; set; }
     
        [RegularExpression(@"^(?:\+?88)?01[15-9]\d{8}$", ErrorMessage = "Phone Number Is Not Valid")]
        public string Phone { get; set; }
    
        [StringLength(12, MinimumLength = 8)]
      
        public string Password { get; set; }
        [Required(ErrorMessage = "Enter Your Confirm Password")]
        [Compare("Password", ErrorMessage = "Password Does Not Match")]
        [Display(Name = "Confirm Password")]
       
        public string ConfirmPassword { get; set; }
    }
}