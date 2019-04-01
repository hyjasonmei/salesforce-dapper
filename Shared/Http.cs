using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SforceDapper.Models;

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
        public HttpResponse Post(string url, string accessToken, object json)
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.Headers.Add("Authorization", "OAuth " + accessToken);
                try
                {
                    var response = client.UploadString(url, JsonConvert.SerializeObject(json));
                    var responseString = response;
                    return new HttpResponse()
                    {
                        IsSuccess = true,
                        Body = responseString
                    };
                }
                catch (WebException ex)
                {
                    // failed...
                    if (ex.Response != null)
                        using (StreamReader r = new StreamReader(ex.Response.GetResponseStream()))
                        {
                            string responseContent = r.ReadToEnd();
                            return new HttpResponse()
                            {
                                IsSuccess = false,
                                Body = responseContent
                            }; ;
                        }
                    throw;
                }
            }
        }

        public HttpResponse Patch(string url, string accessToken, object json)
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.Headers.Add("Authorization", "OAuth " + accessToken);
                try
                {
                    var response = client.UploadString(url, "PATCH", JsonConvert.SerializeObject(json));
                    var responseString = response;
                    return new HttpResponse()
                    {
                        IsSuccess = true,
                        Body = responseString
                    };
                }
                catch (WebException ex)
                {
                    // failed...
                    if (ex.Response != null)
                        using (StreamReader r = new StreamReader(ex.Response.GetResponseStream()))
                        {
                            string responseContent = r.ReadToEnd();
                            return new HttpResponse()
                            {
                                IsSuccess = false,
                                Body = responseContent
                            }; ;
                        }
                    throw;
                }
            }
        }

        public HttpResponse Delete(string url, string accessToken)
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.Headers.Add("Authorization", "OAuth " + accessToken);
                try
                {
                    var response = client.UploadString(url, "DELETE", "");
                    var responseString = response;
                    return new HttpResponse()
                    {
                        IsSuccess = true,
                        Body = responseString
                    };
                }
                catch (WebException ex)
                {
                    // failed...
                    if (ex.Response != null)
                        using (StreamReader r = new StreamReader(ex.Response.GetResponseStream()))
                        {
                            string responseContent = r.ReadToEnd();
                            return new HttpResponse()
                            {
                                IsSuccess = false,
                                Body = responseContent
                            }; ;
                        }
                    throw;
                }
            }
        }
    }
}
