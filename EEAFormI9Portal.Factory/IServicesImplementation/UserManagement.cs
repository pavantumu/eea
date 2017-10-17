using EEAFormI9Portal.EF;
using EEAFormI9Portal.Factory.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEAFormI9Portal.Factory.IServicesImplementation
{
    public class UserManagement : IUserManagement
    {
        private readonly EEAFORMI9Entities db = new EEAFORMI9Entities();

        public List<AspNetUser> GetUserDetails()
        {
            return db.AspNetUsers.ToList();
        }
    }
}
