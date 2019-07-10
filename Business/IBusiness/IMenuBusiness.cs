using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Model;

namespace Business.IBusiness
{
    public interface IMenuBusiness
    {
        Task<MulitViewResult<MenuModel>> LoadMenu ();
        Task<ViewResult<MenuModel>> AddOrUpdate (MenuModel dto);
        Task<ViewResult<bool>> Delete (int id);
    }
}
