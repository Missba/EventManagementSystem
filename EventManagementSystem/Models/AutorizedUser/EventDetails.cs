using EventManagementSystem.Models.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models.AutorizedUser
{
    public class EventDetails
    {
        [Key]
        public int EventId { get; set; }
        [Required(ErrorMessage = "Select Event Type")]
        public string Type { get; set; }
        public virtual List<Employee> Employee { get; set; }
        public virtual List<BookingEvent> BookingEvent { get; set; }
    }
}