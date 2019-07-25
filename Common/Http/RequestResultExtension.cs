using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Http
{
    public static class RequestResultExtension
    {
        public static void Then<T> (this RequestResult<T> result,Action<RequestResult<T>> then)
        {
            then(result);
        }
    }
}
