using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Data.Access
{
    public class UserAgent
    {
        public User GetUserById (int id)
        {
            using(var context = new TestEntities())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == id);
                return user;
            }
        }

        public User GetUserByName (string userName)
        {
            using(var context = new TestEntities())
            {
                var user = context.Users
                    .Include(u => u.UserRoles)
                    .Include(u => u.UserRoles.Select(ur=>ur.Role))
                    .FirstOrDefault(u => u.UserName == userName);
                return user;
            }
        }
    }
}
