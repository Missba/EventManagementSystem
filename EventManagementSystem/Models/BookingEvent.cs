using EventManagementSystem.Models.Account;
using EventManagementSystem.Models.AutorizedUser;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class BookingEvent
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Event Id")]
        [ForeignKey("EventDetails")]
        public int EventId { get; set; }
        [Required(ErrorMessage = "Enter Venu Id")]
        public int VenuId { get; set; }
        [Required(ErrorMessage = "Enter User Id")]
        public int UserId { get; set; }
     
        public string Food { get; set; }
        public string FoodType { get; set; }
        public string Flower { get; set; }
        public string Lighting { get; set; }
        public string SeatingService { get; set; }
        [DataType(DataType.Date)]
        public int NoGuest { get; set; }
        public string Date { get; set; }
        [ForeignKey("VenuId")]
        public virtual VenuDetails VenuDetails { get; set; }
        [ForeignKey("UserId")]
        public virtual Registration Registration { get; set; }
       
        public virtual EventDetails EventDetails { get; set; }
    }
}