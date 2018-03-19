using EventManagementSystem.BLL;

using EventManagementSystem.Models.Account;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        EventBLL bll = new EventBLL();
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {

                bool log = bll.IsAuthenticate(login);
                if (log)
                {
                    Session["userName"] = login.UserName;
                    Session["Password"] = login.Password;

                    return RedirectToAction("BookingHistory", "Authorized");
                }
                else
                {
                    ViewBag.Message = "Forget Username Or Password";
                    return View(login);
                }
            }
            return View();
        }



        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Registration user)
        {
            EventBLL bll = new EventBLL();
            bool rowAffected = bll.IsInsert(user);
            if (rowAffected)
            {
                ViewBag.Message = "Save Successfull";
                return RedirectToAction("Index","Home");
            }
            else
                ViewBag.Message = "Saved Not Successfully";
            return View();
        }

        public ActionResult LoginType()
        {
            return View();
        }
    }
}

