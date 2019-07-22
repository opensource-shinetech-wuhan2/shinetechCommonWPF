using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Model
{
    public class ViewResultBase
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }

    public class ViewResult<T>:ViewResultBase
    {
        public T Data { get; set; }
        public int TotalCount { get; set; }
        public bool NeedRefresh { get; set; }
    }

    public class MulitViewResult<T> :ViewResultBase
    {
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