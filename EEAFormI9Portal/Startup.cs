using System;
using Microsoft.Owin;
using Owin;
using EEAFormI9Portal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartupAttribute(typeof(EEAFormI9Portal.Startup))]
namespace EEAFormI9Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("systemadmin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "systemadmin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "pavan@mailinator.com";
                user.Email = "pavan@mailinator.com";

                string userpwd = "Freedom@2017";

                var chkUser = UserManager.Create(user, userpwd);

                if (chkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "systemadmin");
                }
            }

            if (!roleManager.RoleExists("admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "admin";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("hr"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "hr";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("employee"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "employee";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("representative"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "representative";
                roleManager.Create(role);
            }


        }
    }
}
