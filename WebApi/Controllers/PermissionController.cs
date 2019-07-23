using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Business.IBusiness;
using Business.Model;
using WebApi.Auth;

namespace WebApi.Controllers
{
    [RoutePrefix("api/permission")]
    public class PermissionController : ApiController
    {
        private IPermissionBusiness _permissionBusiness;

        public PermissionController (IPermissionBusiness permissionBusiness)
        {
            _permissionBusiness = permissionBusiness;
        }

        [HttpGet, HttpPost]
        [Route("GetUserPermissions")]
        [TokenAuthorize("CanViewPermission")]
        public async Task<MulitViewResult<PermissionModel>> GetUserPermissions (int userId)
        {
            var result = await _permissionBusiness.GetUserPermissions(userId);
            return result;
        }
    }
}
