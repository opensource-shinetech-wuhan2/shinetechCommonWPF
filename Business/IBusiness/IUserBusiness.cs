using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Model;

namespace Business.IBusiness
{
    public interface IUserBusiness
    {
        UserModel GetUserById (int id);
        UserModel GetUserByName (string userName);
    }
}
