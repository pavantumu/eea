using EEAFormI9Portal.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEAFormI9Portal.Factory.IServices
{
    public interface IRoleManagement
    {
        List<AspNetRole> GetAllRoles();
    }
}
