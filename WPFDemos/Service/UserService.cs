using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Business.Model;
using Common.Http;
using Newtonsoft.Json;

namespace WPFDemos.Service
{
    public class UserService :ServiceBase
    {
        public ViewResult<string> Login ()
        {
            var url = GetUrl("user/login");
            var para = new
            {
               Username = "admin",
               Pwd = "admin"
            };
            var result = Request<ViewResult<string>>(url,para);
            var token = result.Data;

            Properties.Settings.Default.Token = token;
            Properties.Settings.Default.Save();

            return result;
        }

    }
}
