using EventManagementSystem.Models;
using EventManagementSystem.Models.Account;
using EventManagementSystem.Models.AutorizedUser;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EventManagementSystem.Context
{
    public class EventContext:DbContext
    {
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<VenuDetails> VenuDetails { get; set; }
        public DbSet<EventDetails> EventDetails { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<AssignRole> AssignRoles { get; set; }
        public DbSet<BookingEvent> BookingEvent { get; set; }
        public DbSet<EventServicesDetails> EventServicesDetails { get; set; }
        public DbSet<cost> costs { get; set; }
        
    }
}