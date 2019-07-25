using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Model;

namespace Business.IBusiness
{
    public interface IPermissionBusiness
    {
        Task<IEnumerable<PermissionModel>> GetUserPermissions (int userId);

        IEnumerable<PermissionModel> GetUserPermissions (string userName);
    }
}
