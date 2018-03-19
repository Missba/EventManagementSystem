using EventManagementSystem.Models.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class Feedback
    {
        [Key]
        public int FBId { get; set; }
        public int UserId { get; set; }       
        [Display(Name ="Comment")]
        [Required(ErrorMessage = "Please,Provies Your Valuable Opinion")]
        public string message { get; set; }
       
        public virtual Registration Registration { get; set; }
    }
}