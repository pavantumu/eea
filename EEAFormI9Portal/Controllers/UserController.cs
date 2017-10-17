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
    [Authorize]
    public class UserController : BaseController
    {
        private EEAFORMI9Entities db = new EEAFORMI9Entities();

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
            return View(db.AspNetUsers.ToList());
        }


        [HttpGet]
        public JsonResult GetUserDetails()
        {
            var User = new List<AspNetUser>();

            User = _IUserManagement.GetUserDetails();
            var e = Mapper.Map<List<AspNetUser>>(User);

            return Json(e, JsonRequestBehavior.AllowGet);

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