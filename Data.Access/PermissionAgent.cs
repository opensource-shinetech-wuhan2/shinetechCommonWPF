using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Data.Access
{
    public class PermissionAgent
    {
        public async Task<IEnumerable<Permission>> GetUserPermissions (int userId)
        {
            using(var context = new TestEntities())
            {
                var permissions = await (from user in context.Users.Where(u => u.Id == userId)
                                   join userRole in context.UserRoles on user.Id equals userRole.UserId
                                   join rolePermissionGroup in context.RolePermissionGroups on userRole.Id equals rolePermissionGroup.RoleId
                                   join permissionGroup in context.PermissionGroupPermissions on rolePermissionGroup.PermissionGroupId equals permissionGroup.PermissionGroupId
                                   join permission in context.Permissions on permissionGroup.PermissionId equals permission.Id
                                   select permission).ToListAsync();
                return permissions;
            }
        }
    }
}
