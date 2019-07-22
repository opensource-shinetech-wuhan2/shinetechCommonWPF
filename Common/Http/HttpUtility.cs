using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common.Http
{
    public class HttpUtility
    {
        public static RequestResult Request (string url,string jsonstr,string token,string type="POST")
        {
            RequestResult result = new RequestResult();
            HttpWebResponse response;
            try
            {
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Accept = "text/html,application/xhtml+xml,*/*";
                request.ContentType = "application/json";
                request.Method = type.ToString();
                request.Headers.Add("Authorization",token);

                if(type == "POST")
                {
                    byte[] buffer = encoding.GetBytes(jsonstr);
                    request.ContentLength = buffer.Length;
                    request.GetRequestStream().Write(buffer,0,buffer.Length);
                }
                response = (HttpWebResponse)request.GetResponse();
                
            }
            catch(WebException ex)
            {               
                response = (HttpWebResponse)ex.Response;
            }

            result.StatusCode = Convert.ToInt32(response.StatusCode);
            var rs = response.GetResponseStream();
            using(StreamReader reader = new StreamReader(rs,Encoding.UTF8))
            {
                result.Data = reader.ReadToEnd();               
                return result;
            }
        }
    }
}
