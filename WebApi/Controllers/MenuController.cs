using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Business;
using Business.IBusiness;
using Business.Model;
using WebApi.Auth;

namespace WebApi.Controllers
{
    [RoutePrefix("api/menu")]
    public class MenuController : ApiController
    {       
        private IMenuBusiness _menuBusiness;

        public MenuController (IMenuBusiness menuBusiness)
        {
            _menuBusiness = menuBusiness;
        }

        [HttpGet,HttpPost]
        [Route("LoadMenu")]
        [TokenAuthorize("canViewMenu")]
        public async Task<MulitViewResult<MenuModel>> LoadMenu ()
        {
            var result = await _menuBusiness.LoadMenu();
            return result;
        }

        [HttpPost]
        [Route("AddOrUpdate")]
        [Authorize(Roles = "admin")]
        public async Task<ViewResult<MenuModel>> AddOrUpdate (MenuModel model)
        {
            return await _menuBusiness.AddOrUpdate(model);
        }

        [HttpGet,HttpPost]
        [Route("Delete")]
        public async Task<ViewResult<bool>> Delete (int id)
        {
            return await _menuBusiness.Delete(id);
        }
    }
}
