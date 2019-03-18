using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SforceDapper.Shared
{
    internal class Http
    {
        public string Get(string instanceUrl, string accessToken)
        {
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                client.Headers.Add("Authorization", "OAuth " + accessToken);
                var responseString = client.DownloadString(instanceUrl);
                return responseString;
            }
        }
        public string Post(string url, NameValueCollection postdata)
        {
            using (var client = new WebClient())
            {
                var response = client.UploadValues(url, postdata);
                var responseString = Encoding.Default.GetString(response);
                return responseString;
            }
        }
    }
}
