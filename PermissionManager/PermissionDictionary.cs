using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionManager
{
    public class PermissionDictionary :Dictionary<string,List<string>>
    {
        public void AddPermission (string userName,string permission)
        {
            List<string> permissions;
            if(TryGetValue(userName,out permissions))
            {

            }
        }
    }
}
