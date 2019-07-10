using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Model;
using Business.IBusiness;
using DataModel;
using Data.Access;
using Common.Log;
using Business.Common;

namespace Business
{
    public class MenuBusiness:IMenuBusiness
    {
        private IMapper _mapper;
        private MenuAgent _menuAgent;

        public MenuBusiness (IMapper mapper)
        {
            _mapper = mapper;
            _menuAgent = new MenuAgent();
        }

        public async Task<MulitViewResult<MenuModel>> LoadMenu ()
        {
            var result = new MulitViewResult<MenuModel>();
            try
            {
                var menu = await _menuAgent.GetAll();
                var menuDtos = _mapper.Map<List<MenuModel>>(menu);
                menuDtos = menuDtos.Where(m => m.Parent == null).ToList();
                result.Datas = menuDtos;
                result.AllCount = menuDtos.Count;
            }
            catch(Exception ex)
            {
                result.Status = -1;
                var err = Error.Create(ex);
                result.Message = err.ErrorMessage;
                Logger.WriteErrorLog(ex,err.ErrorCode);
            }            
            return result;
        }

        public async Task<ViewResult<MenuModel>> AddOrUpdate (MenuModel dto)
        {
            var result = new ViewResult<MenuModel>();
            try
            {
                var entity = _mapper.Map<Menu>(dto);
                var menu = await _menuAgent.AddOrUpdate(entity);
                var menuDto = _mapper.Map<MenuModel>(menu);
                result.Data = menuDto;
                return result;
            }
            catch(Exception ex)
            {
                result.Status = -1;
                var err = Error.Create(ex);
                result.Message = err.ErrorMessage;
                Logger.WriteErrorLog(ex,err.ErrorCode);
            }
            return result;
        }

        public async Task<ViewResult<bool>> Delete (int id)
        {
            var result = new ViewResult<bool>();
            try
            {
                var succeed =  await _menuAgent.Delete(id);
                result.Data = succeed;
                return result;
            }
            catch(Exception ex)
            {
                result.Status = -1;
                var err = Error.Create(ex);
                result.Message = err.ErrorMessage;
                Logger.WriteErrorLog(ex,err.ErrorCode);
            }
            return result;
        }

    }
}
