# salesforce-dapper

```csharp
class Program
    {
        static void Main(string[] args)
        {
            var tokenUrl = "https://test.salesforce.com/services/oauth2/token";
            var clientId = "{YOUR CLIENT ID}";
            var clientScrect = "{YOUR CLIENT SCRECT}";
            var username = "{YOUR USERNAME}";
            var password = "{YOUR PASSWROD}";
            //login sfdc
            var dapper = new SforceDapper.SforceDapper(tokenUrl, clientId, clientScrect, username, password);
            //query sfdc data
            var soql = "select Id, Name from Account limit 10";
            var accounts = dapper.Query<Account>(soql).records.ToList();
        }
    }
}
```
