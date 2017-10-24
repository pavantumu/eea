using EEAFormI9Portal.EF;
using EEAFormI9Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEAFormI9Portal.Factory.IServices
{
    public interface IUserManagement
    {
        List<AspNetUser> GetUserDetails();
        ViewUserDetails GetUserById(string Id);
        ViewUserDetails UpdateUserDetails(ViewUserDetails user);
        bool DeleteUser(string Id);
        List<AspNetUser> GetUserAndRoleDetails();
        List<AspNetUser> GetHrDetails();
        Representative AddRepresentative(Representative model);
        List<Representative> GetRepresentativeDetails();
        bool ConfirmAccount(object data);
    }
}
