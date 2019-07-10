using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Model
{
    public class ViewResult<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public int TotalCount { get; set; }
        public bool NeedRefresh { get; set; }
    }

    public class MulitViewResult<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public List<T> Datas { get; set; }
        public int AllCount { get; set; }
        public MulitViewResult ()
        {
            Datas = new List<T>();
            Status = 0;
            AllCount = 0;
        }
    }
}