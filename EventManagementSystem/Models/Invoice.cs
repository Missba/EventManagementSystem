using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Models
{
    public class Invoice
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string VenuName { get; set; }
        public string Item { get; set; }
        public int Cost { get; set; }
       
        public int NoGuest { get; set; }

    }
}