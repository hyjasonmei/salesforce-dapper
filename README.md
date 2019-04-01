# salesforce-dapper

1. import this project
2. sample demo :

## Initial

```csharp
static void Main(string[] args)
{
    var tokenUrl = "https://test.salesforce.com/services/oauth2/token";
    var clientId = "{YOUR CLIENT ID}";
    var clientScrect = "{YOUR CLIENT SCRECT}";
    var username = "{YOUR USERNAME}";
    var password = "{YOUR PASSWROD}";
    //login sfdc
    var dapper = new SforceDapper.SforceDapper(tokenUrl, clientId, clientScrect, username, password);
    
}
```

## Query

```csharp
class Account {
	public string Id { get; set; }
	public string Name { get; set; }
}

class Program
    {
        static void Main(string[] args)
        {
			... Initial
            //query sfdc data
            string soql = "select Id, Name from Account limit 10";
            List<Account> accounts = dapper.Query<Account>(soql).records.ToList();
        }
    }
}
```

