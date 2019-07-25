using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Model;

namespace WPFDemos.Common
{
    public static class PermissionManager
    {
        public static List<string> Permissions = new List<string>();

        public static void Init(List<PermissionModel> permissions)
        {
            Permissions.Clear();
            foreach(var permision in permissions)
            {
                Permissions.Add(permision.Name);
            }
        }

        public static bool HasPermission (string action)
        {
            return Permissions.Contains(action);
        }
    }
}
