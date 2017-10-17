using EEAFormI9Portal.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEAFormI9PortalFactory.IServicesImplementation
{
    class UserManagement : IServices.UserManagement
    {
        private EEAFORMI9Entities entityDB = new EEAFORMI9Entities();

        public void getUserDetails()
        {
            throw new NotImplementedException();
        }
    }
}
