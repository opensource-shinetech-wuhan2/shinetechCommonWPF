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
        public async Task<MulitViewResult<PermissionModel>> GetUserPermissions (int userId)
        {
            var result = new MulitViewResult<PermissionModel>();
            var data = await _permissionBusiness.GetUserPermissions(userId);
            result.Datas = data.ToList();
            result.AllCount = data.Count();
            return result;
        }
    }
}
