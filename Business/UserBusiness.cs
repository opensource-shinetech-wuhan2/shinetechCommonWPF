using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.IBusiness;
using Business.Model;
using Data.Access;

namespace Business
{
    public class UserBusiness:IUserBusiness
    {
        private IMapper _mapper;
        private UserAgent _userAgent;
        public UserBusiness (IMapper mapper)
        {
            _mapper = mapper;
            _userAgent = new UserAgent();
        }

        public UserModel GetUserById (int id)
        {
            var user = _userAgent.GetUserById(id);
            var userModel = _mapper.Map<UserModel>(user);
            return userModel;
        }

        public UserModel GetUserByName (string userName)
        {
            var user = _userAgent.GetUserByName(userName);
            var userModel = _mapper.Map<UserModel>(user);
            return userModel;
        }
    }
}
