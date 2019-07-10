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
    public class HttpPostUtility
    {
        public static string Request (string url,string jsonstr,string token,string type="POST")
        {
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); 
            request.Accept = "text/html,application/xhtml+xml,*/*";
            request.ContentType = "application/json";
            request.Method = type.ToUpper().ToString();
            request.Headers.Add("Authorization",token);

            if(type == "POST")
            {
                byte[] buffer = encoding.GetBytes(jsonstr);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer,0,buffer.Length);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using(StreamReader reader = new StreamReader(response.GetResponseStream(),Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
