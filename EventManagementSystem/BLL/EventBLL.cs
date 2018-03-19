using EventManagementSystem.Context;
using EventManagementSystem.DLL;
using EventManagementSystem.Models;
using EventManagementSystem.Models.Account;
using EventManagementSystem.Models.AutorizedUser;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManagementSystem.BLL
{
    public class EventBLL
    {
        EventContext db = new EventContext();
        EventDLL dll = new EventDLL();
        public bool IsInsert(Registration user)
        {
            bool rowAffected = false;
            rowAffected = dll.CreateUser(user);
            if(rowAffected)
            {
                rowAffected = true;
            }
            return rowAffected;
        }
        public bool IsAuthenticate(Login log)
        {
           
            bool isLog = false;
            if(log.UserName!=null && log.Password!=null)
            {
                 isLog=dll.LoginUser(log);
                
            }
            return isLog ;
        }

        public IPagedList EventList(int page)
        {
            var data = dll.EventHistory(page);
            return data;
        }
        public List<BookingEvent> EventListId()
        {
            var data = dll.EventHistoryId();
            return data;
        }
        public bool IsUpdate(UpdateInfo user)
        {
          
            bool rowAffected = dll.UpdateInfo(user);
            if(rowAffected)
            {
                return rowAffected;
            }
            return rowAffected;
        }
        public List<VenuDetails> ListOfVenu()
        {
            var data = dll.VenuList();
            return data;
        }
        public int GetId(string name)
        {
            int id = dll.GetId(name);
            return id;
        }
        public bool Comment(Feedback fd)
        {
            
            bool log = dll.Comment(fd);
            if(log)
            {
                return true;
            }
            return false;
        }
        public bool EmployeeInsert(Employee user)
        {
            bool rowAffected = false;
           
            rowAffected = dll.CreateEmployee(user);
            if (rowAffected)
            {
                rowAffected = true;
            }
            return rowAffected;
        }

        public bool EmpLogin(EmpLogin log)
        {
            bool islogin;
            islogin = dll.EmpLogin(log);
            return islogin;
        }

        public bool IsAddVenu(VenuDetails venu)
        {
            bool isAdd = false;
            isAdd=dll.AddVenu(venu);
            return isAdd;
        }
        public bool IsAddEvent(EventDetails ev)
        {
            bool isAdd = false;
            isAdd = dll.AddEvent(ev);
            return isAdd;
        }

        public List<int> EmployeeId()
        {
            var data = dll.EmployeeList();
            return data;
        }
        public bool AddRole(AssignRole a)
        {
            bool row = dll.AssignRole(a);
            if (row)
                return true;
            else
                return false;
        }
        public bool Booking(BookingEvent b)
        {
            bool row;
            row = dll.BookAnEvent(b);
            if (row)
                return row;
            else
                return row;
        }
        public bool EventSer(EventServicesDetails b)
        {
            bool row;
            row = dll.EventService(b);
            if (row)
                return row;
            else
                return row;
        }
        public List<Employee> EmployeeDetails()
        {
            var data = dll.EmployeeDetails();
            return data;
        }
        public int TotalCost(BookingEvent b)
        {

            var data = db.costs.ToList();
            int amount=0;
            int guest = b.NoGuest;
            int foodcost = 0, foodtypecost = 0, flowercost = 0, lightcost = 0, seatcost = 0;
            //for lighting
            foreach (var d in data)
            {
                if (b.Lighting.Equals(d.Items))
                {
                    lightcost = d.Cost;
                    //amount += lightcost;
                }
                //if (b.Lighting.Equals(d.Items))
                //{
                //    lightcost = d.Cost;
                //    amount += lightcost;
                //}
                //if (b.Lighting.Equals(d.Items))
                //{
                //    lightcost = d.Cost;
                //    amount += lightcost;
                //}
                //seating service
                if (b.SeatingService.Equals(d.Items))
                {
                    seatcost = d.Cost;
                   // amount += seatcost;
                }
                //if (b.SeatingService.Equals(d.Items))
                //{
                //    seatcost = d.Cost;
                //    amount += seatcost;
                //}
                //if (b.SeatingService.Equals(d.Items))
                //{
                //    seatcost =d.Cost;
                //    amount += seatcost;
                //}
                //food type
                if (b.FoodType.Equals(d.Items))
                {
                    foodtypecost = d.Cost;
                   // amount += foodtypecost;
                }
                //if (b.FoodType.Equals(d.Items))
                //{
                //    foodtypecost = d.Cost;
                //    amount += foodtypecost;
                //}
                //if (b.FoodType.Equals(d.Items))
                //{
                //    foodtypecost = d.Cost;
                //    amount += foodtypecost;

                //}
                //if (b.FoodType.Equals(d.Items))
                //{
                //    foodtypecost = d.Cost;
                //    amount += foodtypecost;
                //}
                //if (b.FoodType.Equals(d.Items))
                //{
                //    foodtypecost = d.Cost;
                //    amount += foodtypecost;
                //}

                //decoration
                if (b.Flower.Equals(d.Items))
                {
                    flowercost = d.Cost;

                }
               
                //if (b.Flower.Equals(d.Items))
                //{
                //    flowercost = d.Cost;
                //}
                //if (b.Flower.Equals(d.Items))
                //{
                //    flowercost = d.Cost;
                //}
                if (b.Food.Equals(d.Items))
                {
                    foodcost = d.Cost;
                }
                //if (b.Food.Equals(d.Items))
                //{
                //    foodcost = d.Cost;
                //}
            }
                amount = (foodcost * guest) + (flowercost * guest) + (foodtypecost * guest) + (lightcost * guest) + (seatcost * guest);
                return amount;
           
        }

        public List<EventServicesDetails> Details()
        {
            var data = dll.EventSer();
            return data;
        }
        public List<EventDetails> EventDetails()
        {
            var data = dll.EventDetails();
            return data;
        }

        public List<cost> CostList()
        {
            var data = dll.costs();
            return data;
        }
    }
}