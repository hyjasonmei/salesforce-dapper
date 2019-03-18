using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using SforceDapper.Models;
using SforceDapper.Shared;

namespace SforceDapper
{
    public class SforceDapper
    {
        private readonly SforceSession _session;
        public SforceDapper(string tokenUrl, string clientId, string clientSecret, string username, string password)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            _session = new Services.Salesforce().LoginRest(tokenUrl, clientId, clientSecret, username, password);
        }
        public SforceQueryResult<T> Query<T>(string sql)
        {
            //first query
            sql = HttpUtility.UrlEncode(sql);
            var http = new Http();
            var url = string.Format(_session.instance_url + "/services/data/v20.0/query/?q={0}", sql);
            var result = http.Get(url, _session.access_token);
            var resultT = (SforceQueryResult<T>)JsonConvert.DeserializeObject(result, typeof(SforceQueryResult<T>));
            if (resultT.done || resultT.nextRecordsUrl == null)
                return resultT;
            //remain query
            var remainDone = false;
            var nextUrl = resultT.nextRecordsUrl;
            while (!remainDone && !string.IsNullOrEmpty(nextUrl))
            {
                var remainUrl = _session.instance_url + nextUrl;
                var remainResultStr = http.Get(remainUrl, _session.access_token);
                var remainResult = (SforceQueryResult<T>)JsonConvert.DeserializeObject(remainResultStr, typeof(SforceQueryResult<T>));
                foreach (var record in remainResult.records)
                {
                    resultT.records.Add(record);
                }
                remainDone = remainResult.done;
                nextUrl = remainResult.nextRecordsUrl;
            }
            return resultT;
        }
    }
}
