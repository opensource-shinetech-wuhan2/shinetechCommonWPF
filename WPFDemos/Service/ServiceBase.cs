using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Common.Http;
using Newtonsoft.Json;
using WPFDemos.Common;

namespace WPFDemos.Service
{
    public class ServiceBase
    {
        protected static readonly string ApiBaseUrl = ConfigurationManager.AppSettings["baseApiUrl"];

        public string GetUrl (string path)
        {
            return ApiBaseUrl + path;
        }

        protected virtual T Request<T> (string url,object para,string type = "POST")
        {
            var jsonPara = JsonConvert.SerializeObject(para);
            var accessToken = "Bearer " + Properties.Settings.Default.Token;
            var requestResult = HttpUtility.Request(url,jsonPara,accessToken,type);

            if(requestResult.StatusCode != 200)//error
            {
                WindowManager.ShowErrorWindow(requestResult.StatusCode);
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(requestResult.Data);
        }
    }
}
