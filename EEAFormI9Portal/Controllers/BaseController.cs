using EEAFormI9Portal.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EEAFormI9Portal.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationSignInManager _signInManager = null;
        protected ApplicationUserManager _userManager = null;
        protected ApplicationDbContext context;
        //protected Helper _dbhelp;

        public BaseController()
        {
            context = new ApplicationDbContext();
            //_dbhelp = new Helper();
        }

        public BaseController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
    }
}