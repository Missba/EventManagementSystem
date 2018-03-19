using EventManagementSystem.BLL;
using EventManagementSystem.Context;
using EventManagementSystem.Models;
using EventManagementSystem.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagementSystem.Controllers
{
   
    public class AuthorizedController : Controller
    {
        EventContext Cont = new EventContext();
       
        // GET: Authorized
        EventBLL bll = new EventBLL();
        [HttpGet]
        public ActionResult BookingEvent(string name)
        {
            List<SelectListItem> flower = new List<SelectListItem>() { };
            List<SelectListItem> item = new List<SelectListItem>() { };
            int id=bll.GetId(name);
            ViewBag.UserId = id;
            var data = bll.ListOfVenu();
            foreach(var d in data)
            {
                item.Add(new SelectListItem { Value = d.VenuId.ToString(), Text = d.VenuName.ToString() });
            }
            
            var list = bll.EventDetails();
            List<SelectListItem> evlist = new List<SelectListItem>() { };
            foreach(var da in list)
            {
                evlist.Add(new SelectListItem { Value = da.EventId.ToString(), Text = da.Type.ToString() });
            }

            ViewBag.data = item;
            ViewBag.list = evlist;

            var listser = bll.Details();
            List<SelectListItem> food = new List<SelectListItem>() { };
            foreach (var da in listser)
            {
                if (da.Food == null)
                    break;
                food.Add(new SelectListItem { Value = da.Food.ToString(), Text = da.Food.ToString() });
            }
            List<SelectListItem> seat = new List<SelectListItem>() { };
            foreach (var da in listser)
            {
                if (da.SeatingService == null)
                    break;
                seat.Add(new SelectListItem { Value = da.SeatingService.ToString(), Text = da.SeatingService.ToString() });
            }
           
            foreach (var da in listser)
            {
                if (da.Flower == null)
                    break;
                flower.Add(new SelectListItem { Value = da.Flower.ToString(), Text = da.Flower.ToString() });
            }
            List<SelectListItem> ftype = new List<SelectListItem>() { };
            foreach (var da in listser)
            {
                if (da.FoodType == null)
                    break;
                ftype.Add(new SelectListItem { Value = da.FoodType.ToString(), Text = da.FoodType.ToString() });
            }
            List<SelectListItem> light = new List<SelectListItem>() { };
            foreach (var da in listser)
            {
                if (da.Lighting == null)
                    break;
                light.Add(new SelectListItem { Value = da.Lighting.ToString(), Text = da.Lighting.ToString() });
            }
            ViewBag.food = food;
            ViewBag.foodtype = ftype;
            ViewBag.light = light;
            ViewBag.seat = seat;
            ViewBag.flower = flower;
            return View();
        }
        [HttpPost]
        public ActionResult BookingEvent(BookingEvent b)
        {
           
            bool data= bll.Booking(b);
            if (data)
            {
               
                return RedirectToAction("Invoice", "Authorized");
            }
               
            else
                return View();
        }
        public ActionResult BookingHistory()
        {
            var data = bll.EventList(3);
            return View(data);
        }

      
        [HttpGet]
        public ActionResult FeedBack(string name)
        {
            int id = bll.GetId(name);
            ViewBag.Id=id;
            return View();
        }
        [HttpPost]
        public ActionResult FeedBack(Feedback fd)
        {
            bool rowAffected = bll.Comment(fd);
            if (rowAffected)
            {
                ViewBag.Message = "Save Successfull";
                Response.Redirect("BookingHistory");
            }
            else
                ViewBag.Message = "Saved Not Successfully";
            return View();
        }
        [HttpGet]
        public ActionResult UpdateInfo()
        {
            int id = Convert.ToInt16(Session["UId"]);
            var log = Cont.Registrations.Where(m => m.UserId==id);
            return View();
        }
        [HttpPost]
        public ActionResult UpdateInfo(UpdateInfo user)
        {
            bool rowAffected = bll.IsUpdate(user);
            if(rowAffected)
            {
                return View("/BookingHistory");
            }
            else
                return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return View();
        }

        public ActionResult EventService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EventService(EventServicesDetails ev)
        {
            bool data = bll.EventSer(ev);
            if (data)
                return RedirectToAction("BookingHistory", "Authorized");
            return View();
        }

        public ActionResult EmployeeDetails()
        {
            var data = bll.EmployeeDetails();
            return View(data);
        }
        public ActionResult Invoice()
        {
            var c = bll.CostList();
            var ev = bll.EventListId();
            ViewBag.C = c;
            ViewBag.Ev = ev;
           
            return View();
        }
    }
}