using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Common;
using Business.IBusiness;
using Business.Model;
using Common.Log;
using Data.Access;

namespace Business
{
    public class PermissionBusiness:IPermissionBusiness
    {
        private IMapper _mapper;
        private PermissionAgent _permissionAgent;
        public PermissionBusiness (IMapper mapper)
        {
            _mapper = mapper;
            _permissionAgent = new PermissionAgent();
        }

        public async Task<MulitViewResult<PermissionModel>> GetUserPermissions (int userId)
        {
            var result = new MulitViewResult<PermissionModel>();

            var permissions = await _permissionAgent.GetUserPermissions(userId);
            var permissionList = _mapper.Map<List<PermissionModel>>(permissions);
            result.Datas = permissionList;
            result.AllCount = permissionList.Count;

            return result;         
        }
    }
}
