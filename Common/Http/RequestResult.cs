using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Http
{
    public class RequestResult<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }

        public bool HasError ()
        {
            return StatusCode != 200;
        }
    }
}
