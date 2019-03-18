using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SforceDapper.Models;
using SforceDapper.Shared;

namespace SforceDapper.Services
{
    class Salesforce
    {
        public SforceSession LoginRest(string tokenUrl, string clientId, 
            string clientSecret, string username, string password)
        {
            string url = tokenUrl;
            var values = new NameValueCollection();
            values["grant_type"] = "password";
            values["client_id"] = clientId;
            values["client_secret"] = clientSecret;
            values["username"] = username;
            values["password"] = password;
            string result = new Http().Post(url, values);
            var session = (SforceSession)JsonConvert.DeserializeObject(result, typeof(SforceSession));
            session.username = values["username"];
            session.issue_date = DateTime.Now;
            return session;
        }
    }
}
