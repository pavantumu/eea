using EEAFormI9Portal.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EEAFormI9Portal.Models
{
    public class ViewUserAndRoleDetails
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        //public List<String> RoleName { get; set; }
        //public ICollection<AspNetRole> Role { get; set; }
    }
}