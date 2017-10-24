using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EEAFormI9Portal.EF;
using EEAFormI9Portal.Models;
using AutoMapper;

namespace EEAFormI9Portal.Controllers
{
    [Authorize(Roles="systemadmin")]
    public class RolesController : BaseController
    {
        private EEAFORMI9Entities db = new EEAFORMI9Entities();


        [HttpGet]
        public JsonResult GetUserDetails()
        {
            //var User = new List<AspNetUser>();
            var User1 = new List<ViewUserAndRoleDetails>();

            User1 = _IUserManagement.GetUserAndRoleDetails();
            
            //var e = Mapper.Map<List<ViewUserAndRoleDetails>>(User1);

            return Json(User1, JsonRequestBehavior.AllowGet);

        }


        public ActionResult Dashboard()
        {
            return View();
        }

        // GET: Roles
        public ActionResult Index()
        {
            return View(db.AspNetUsers.ToList());
        }

        // GET: Roles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] AspNetUser aspNetUser)
        {
            if (ModelState.IsValid)
            {
                db.AspNetUsers.Add(aspNetUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aspNetUser);
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var aspNetUser = db.AspNetUsers.Find(id);
            //var aspNetRoles = db.AspNetRoles.ToList();
            //if (aspNetUser == null)
            //{
            //    return HttpNotFound();
            //}
            var model = new UserRoleViewModel()
            {
                Users = db.AspNetUsers.Find(id),
                Roles = db.AspNetRoles.ToList()
            };
            var listItems = new List<SelectListItem>();
            foreach (var role in model.Roles)
            {
                listItems.Add(new SelectListItem
                {
                    Value = role.Id,
                    Text = role.Name
                });
            }
            ViewBag.ListOfRoles = listItems;

            return View(model);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] AspNetUser aspNetUser)
        //public ActionResult Edit(UserRoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspNetUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aspNetUser);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            db.AspNetUsers.Remove(aspNetUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
