using System;
using System.Collections.Generic;
using System.Linq;
using EventManagementSystem.Models.Account;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace EventManagementSystem.Models.Account
{
    public class Registration
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Enter Name")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter City Name")]
        public string City { get; set; }
        [Required(ErrorMessage = "Enter Country Name")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Enter Your Email Address")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email Address Not Valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Number Is Required")]
        [RegularExpression(@"^(?:\+?88)?01[15-9]\d{8}$", ErrorMessage = "Phone Number Is Not Valid")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Enter Your Password")]
        [StringLength(12, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Enter Your Confirm Password")]
        [Compare("Password", ErrorMessage = "Password Does Not Match")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string ConfirmPassword { get; set; }
        public virtual List<Feedback> Feedback { get; set; }
        public virtual List<BookingEvent> BookingEvent { get; set; }
    }
}