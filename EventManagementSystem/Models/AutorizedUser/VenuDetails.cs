using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models.AutorizedUser
{
    public class VenuDetails
    {
        [Key]
        public int VenuId { get; set; }
        [Required(ErrorMessage = "Select Venu")]
        public string VenuName { get; set; }
        [Required(ErrorMessage ="Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter Cost")]
        public int Cost { get; set; }
        [Required(ErrorMessage = "Type No Of Guest Capacity")]
        [Range(100,1500)]
        public int GuestCapacity { get; set; } 
        public virtual List<BookingEvent> BookingEvent { get; set; }

    }
}