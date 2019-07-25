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
    public class MenuService :ServiceBase
    {
        public RequestResult<MulitViewResult<MenuModel>> LoadMenu ()
        {
            var url = GetUrl("menu/LoadMenu");
            var result = Request<MulitViewResult<MenuModel>>(url,"");
            return result;
        }

        public RequestResult<ViewResult<MenuModel>> AddOrUpdate (MenuModel model)
        {
            var url = GetUrl("menu/AddOrUpdate");
            var result = Request<ViewResult<MenuModel>>(url,model);
            return result;
        }

        public RequestResult<ViewResult<bool>> Delete (int id)
        {
            var url = GetUrl("menu/Delete?id=" + id);
            var para = new { Id = id };
            var result = Request<ViewResult<bool>>(url,para,"GET");
            return result;
        }
    }
}
