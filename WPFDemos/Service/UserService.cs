using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Business.Model;
using Common.Http;
using GalaSoft.MvvmLight.Ioc;
using Newtonsoft.Json;
using WPFDemos.Common;

namespace WPFDemos.Service
{
    public class UserService :ServiceBase
    {
        public RequestResult<LoginViewResult> Login ()
        {
            var url = GetUrl("user/login");
            var para = new
            {
               Username = "admin",
               Pwd = "admin"
            };

            string token = string.Empty;
            var result = Request<LoginViewResult>(url,para);

            Properties.Settings.Default.Token = token;
            Properties.Settings.Default.Save();

            var permissions = result.Data.Permissions;

            PermissionManager.Init(permissions);
            return result;
        }

    }
}
