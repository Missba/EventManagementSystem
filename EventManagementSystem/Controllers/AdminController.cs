using EventManagementSystem.BLL;
using EventManagementSystem.Models.Account;
using EventManagementSystem.Models.AutorizedUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        EventBLL bll = new EventBLL();
        // GET: Admin
        [HttpGet]
        public ActionResult Create()
        {

             return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            bll.EmployeeInsert(employee);
            return RedirectToAction("EmployeeDetails","Authorized");
        }
        [HttpGet]
        public ActionResult AssignRole()
        {
            var id = bll.EmployeeId();
            var data = ListRole();
            List<SelectListItem> itemlist =new List<SelectListItem>() { };
            foreach(var item in data)
            {
                itemlist.Add(
                new SelectListItem { Value = item.Role.ToString(), Text = item.Role.ToString() });
            }
            ViewBag.Id = id;
            ViewBag.items = itemlist;
            return View();
        }

        [HttpPost]
        public ActionResult AssignRole(AssignRole emp)
        {
            bool row;
            row = bll.AddRole(emp);
            if (row)
                return RedirectToAction("EmployeeDetails", "Authorized");
            else
                return View();
        }
        [HttpGet]
        public ActionResult EmpLogin()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult EmpLogin(EmpLogin log)
        {
            bool login = bll.EmpLogin(log);
            if(login==true)
            {
                if (log.Name.Equals("admin@gmail.com") && log.Password.Equals("admin123"))
                {
                    return RedirectToAction("Create", "Admin");
                }
                else
                {
                    Session["user"] = log.Name;
                    Session["Pass"] = log.Password;
                    return RedirectToAction("BookingHistory", "Authorized");
                }
            }
            return View();
        }
        public ActionResult EmpLogout()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            return View();
        }

       
        public ActionResult VenuDetails()
        {
            var data = bll.ListOfVenu();
            return View(data);
        }

        public ActionResult AddVenu()
        {
            return View();
        }
      [HttpPost]
        public ActionResult AddVenu(VenuDetails venu)
        {
            bool isAdd = false;
            isAdd = bll.IsAddVenu(venu);
            if(isAdd)
            {
                return RedirectToAction("VenuDetails", "Admin");
            }

            return View();
        }
        [HttpGet]
        public ActionResult AddEvent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEvent(EventDetails en)
        {
            bool isAdd = false;
            isAdd = bll.IsAddEvent(en);
            if (isAdd)
            {
                return RedirectToAction("BookingHistory", "Authorized");
            }

            return View();
        }


        private List<AssignRole> ListRole()
        {
            return new List<AssignRole>
            {
                new AssignRole { Role="Manager"},
                new AssignRole {Role="Officer" },
                new AssignRole {Role="HRM"},
                new AssignRole {Role="Staff" }
            };
        }
    }
}