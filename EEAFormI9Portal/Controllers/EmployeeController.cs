using EEAFormI9Portal.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EEAFormI9Portal.Controllers
{
    public class EmployeeController : BaseController
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SendEmailPassword(string email)
        {
            var sendToEmail = email;
            if (sendToEmail != null)
            {
                var result = _IEmailManagement.SendEmailPassword(sendToEmail);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> ConfirmAccount(ResetPasswordViewModel model)
        {
            //if(data != null)
            //{
            //    var result = _IUserManagement.ConfirmAccount(data);
            //}
            //return Json(true, JsonRequestBehavior.AllowGet);
            if (!ModelState.IsValid)
            {
                //return View(model);
            }
            var user1 = db.AspNetUsers.SingleOrDefault(x => x.Email == model.Email);
            var user = UserManager.FindByEmail(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                //return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            else if (model.Code == user1.TempCode)
            {
                string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var result = await UserManager.ResetPasswordAsync(user.Id, code, model.Password);
                if (result.Succeeded)
                {
                    //return RedirectToAction("Index", "Home");
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            //var result = UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            //if (result.Succeeded)
            //{
            //    //return RedirectToAction("ResetPasswordConfirmation", "Account");
            //}
            //AddErrors(result);
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }
    }
}