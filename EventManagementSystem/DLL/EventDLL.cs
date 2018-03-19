using EventManagementSystem.Context;
using EventManagementSystem.Models;
using EventManagementSystem.Models.Account;
using EventManagementSystem.Models.AutorizedUser;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;

namespace EventManagementSystem.DLL
{
    public class EventDLL
    {
        EventContext db = new EventContext();
        public bool CreateUser(Registration user)
        {
            bool isInsert = false;
            int rowAffected;
            db.Registrations.Add(user);
            rowAffected = db.SaveChanges();
            if (rowAffected > 0)
            {
                isInsert = true;
            }
            return isInsert;
        }

        public bool LoginUser(Login user)
        {
            bool isLog = false;
            var data = db.Registrations.Where(m => m.Email.Equals(user.UserName) && m.Password.Equals(user.Password)).FirstOrDefault();

            if (data != null)
            {
                isLog = true;
            }
            return isLog;
        }

        public IPagedList EventHistory(int? page)
        {
            var data = db.BookingEvent.ToList().ToPagedList(page??1, 3);
            return data;
        }
        public List<cost> costs()
        {
            var data = db.costs.ToList();
            return data;
        }
        public bool UpdateInfo(UpdateInfo user)
        {

            bool isUpdate = false;
            var data = db.Registrations.Where(m => m.Email.Equals(user.Email)).FirstOrDefault();
            if (data != null)
            {
                data.Address = user.Address;
                data.Phone = user.Phone;
                data.Password = user.Password;
                data.Email = user.Email;
                data.City = user.City;

                db.SaveChanges();
            }
            return isUpdate;
        }
        public List<VenuDetails> VenuList()
        {
            var data = db.VenuDetails.ToList();
            return data;
        }


        public bool Comment(Feedback fd)
        {
            bool log = false;
            int rowAffected;
            db.Feedback.Add(fd);
            rowAffected = db.SaveChanges();
            if (rowAffected > 0)
            {
                log = true;
            }
            return log;

        }
        public int GetId(string name)
        {

            int id = Convert.ToInt16(db.Registrations.Where(m => m.Email.Equals(name)).Select(m => m.UserId).FirstOrDefault());

            return id;
        }

        #region Addemplyee
        public bool CreateEmployee(Employee user)
        {
            bool isInsert = false;
            int rowAffected;
            db.Employees.Add(user);
            rowAffected = db.SaveChanges();
            if (rowAffected > 0)
            {
                isInsert = true;
            }
            return isInsert;
        }

        public bool EmpLogin(EmpLogin log)
        {
            bool islog = false;
            var rowAffected = db.Employees.Where(m => m.Email.Equals(log.Name) && m.Password.Equals(log.Password)).FirstOrDefault();
            if (rowAffected != null)
            {
                islog = true;
                return islog;
            }
            return islog;

        }

        public bool AddVenu(VenuDetails venu)
        {

            db.VenuDetails.Add(venu);
            int rowAffected = db.SaveChanges();
            if (rowAffected > 0)
                return true;
            else
                return false;
        }

        public bool AddEvent(EventDetails even)
        {
            int rowAffected;
            db.EventDetails.Add(even);
            rowAffected = db.SaveChanges();
            if (rowAffected > 0)
                return true;
            else
                return false;
        }
        public List<int> EmployeeList()
        {
            var data = db.Employees.Select(m=>m.EmployeeId).ToList();
            return data;
        }
        public bool AssignRole(AssignRole e)
        {
          
            db.AssignRoles.Add(e);
            int rowAffted=db.SaveChanges();
            if (rowAffted > 0)
                return true;
            else
                return false;
        }

        public bool BookAnEvent(BookingEvent book)
        {
            bool bookEvent = false;
            db.BookingEvent.Add(book);
            int row = db.SaveChanges();
            if (row > 0)
                return bookEvent = true;
            else
                return bookEvent;
        }

        public List<EventServicesDetails> EventSer()
        {
            var data = db.EventServicesDetails.ToList();
            return data;
        }
        public bool EventService(EventServicesDetails book)
        {
            bool bookEvent = false;
            db.EventServicesDetails.Add(book);
            int row = db.SaveChanges();
            if (row > 0)
                return bookEvent = true;
            else
                return bookEvent;
        }

        public List<Employee> EmployeeDetails()
        {
            var list = db.Employees.ToList();
            return list;

        }

        public List<EventDetails> EventDetails()
        {
            var data = db.EventDetails.ToList();
            return data;
        }
        public int BookingId()
        {
            int data = Convert.ToInt32(db.BookingEvent.Max(m => m.Id));
            return data; 
        }
        public List<BookingEvent> EventHistoryId()
        {
            int id = BookingId();
           var data= db.BookingEvent.Where(m=>m.Id==id).ToList();
           return data;
        }


    }
    

}
#endregion