using EEAFormI9Portal.EF;
using EEAFormI9Portal.Factory.IServices;
using EEAFormI9Portal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace EEAFormI9Portal.Controllers
{
    [Authorize(Roles = "hr")]
    public class UserController : BaseController
    {
        //private EEAFORMI9Entities db = new EEAFORMI9Entities();

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                ViewBag.Name = user.Name;
                var s = UserManager.GetRoles(user.GetUserId());

                if (s[0].ToString() == "systemadmin")
                {
                    return RedirectToAction("Index", "Roles");
                }
                else
                {
                    return RedirectToAction("UserDetails", "User");
                }
                //ViewBag.displayMenu = "No";
                //if (isAdminUser())
                //{
                //    ViewBag.displayMenu = "Yes";
                //}
                //return View();
            }
            
            return View();
        }

        public ActionResult UserDetails()
        {
            //return View(db.AspNetUsers.ToList());
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "hr")]
        public JsonResult GetUserDetails()
        {
            var User = new List<AspNetUser>();

            User = _IUserManagement.GetUserDetails();
            var e = Mapper.Map<List<ViewUserDetails>>(User);

            return Json(e, JsonRequestBehavior.AllowGet);

        }

        public ActionResult UpdateUserDetails(string id)
        {
            return View(); 
        }

        [HttpGet]
        public JsonResult GetUserDetailsById(string Id)
        {
            var User = new ViewUserDetails();

            User = _IUserManagement.GetUserById(Id);
            var e = Mapper.Map<ViewUserDetails>(User);

            return Json(e, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateUserDetails(ViewUserDetails user)
        {
            var updateUser = new ViewUserDetails();

            updateUser = _IUserManagement.UpdateUserDetails(user);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteUser(string id)
        {
            bool result;
            result = _IUserManagement.DeleteUser(id);
            return RedirectToAction("UserDetails", "User");
        }

        public ActionResult SendNew()
        {
            return View();
        }


        public ActionResult RepresentativeDetails()
        {
            //return View(db.AspNetUsers.ToList());
            return View();
        }

        [HttpGet]
        public JsonResult GetRepresentativeDetails()
        {
            var User = new List<Representative>();

            User = _IUserManagement.GetRepresentativeDetails();
            var e = Mapper.Map<List<ViewRepresentativeDetails>>(User);

            return Json(e, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddRepresentative(AddRepresentative model)
        {
            if (ModelState.IsValid)
            {
                var Rep = Mapper.Map<Representative>(model);
                Rep.Id += Rep.Id;
                var Representative = _IUserManagement.AddRepresentative(Rep);
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SendEmail(string email)
        {
            var sendToEmail = email;
            if(sendToEmail != null)
            {
                var result = _IEmailManagement.SendEmail(sendToEmail);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }





        // GET: User
        //public ActionResult isAdminUser()
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        var user = User.Identity;
        //        var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

        //        var s = UserManager.GetRoles(user.GetUserId());

        //        if (s[0].ToString() == "systemadmin")
        //        {
        //            return RedirectToAction("Index", "Roles");
        //        }
        //        else
        //        {
        //            return RedirectToAction("Index", "User");
        //        }

        //    }
        //    //return false;

        //    return View();
        //}
    }
}