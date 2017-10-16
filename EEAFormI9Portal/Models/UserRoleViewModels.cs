using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EEAFormI9Portal.EF;
using System.ComponentModel.DataAnnotations;

namespace EEAFormI9Portal.Models
{
    public class UserRoleViewModel
    {
        [Display(Name = "Roles")]
        public List<AspNetRole> Roles { get; internal set; }

        //public string Email { get; set; }
        //public string PhoneNumber { get; set; }
        //public bool LockoutEnabled { get; set; }
        //public int AccessFailedCount { get; set; }
        //public string UserName { get; set; }
        //public string Role { get; set; }
        [Display(Name = "Users")]
        public AspNetUser Users { get; internal set; }

    }
}