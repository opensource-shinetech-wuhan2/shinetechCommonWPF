using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Model;

namespace Business.Common
{
    public class Error
    {
        public static readonly string ErrorCode = Guid.NewGuid().ToString();
        public static Dictionary<Type,string> ExceptionMap = new Dictionary<Type,string>()
        {
            {typeof(DllNotFoundException),"404"},
        };

        public static ErrorModel Create (Exception exception)
        {
            var result = new ErrorModel();
            if(exception is DllNotFoundException)
            {
                result.ErrorCode = "network connection exception";
                result.ErrorMessage = "Sorry,the " + result.ErrorCode + ", please contact the administrator";
            }
            else
            {
                result.ErrorCode = ErrorCode;
                result.ErrorMessage = "Sorry,there is something wrong,the error code is (" + result.ErrorCode + "),please contact the administrator." +
                    "<br/> Error Detail:<br/>" +
                    "<b style=\"color:red;\">" + exception.Message + "</b>";

            }
            return result;
        }
    }
}
