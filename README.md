# PayStack API for .Net
This library makes it easy to consume the [Payment API](http://developers.paystack.co/docs) from .Net projects.

## What's new in 1.0.x !
100% API coverage, simply!  

With this update, all Paystack APIs are now available via the **Type-less** API, exposed directly on `PayStackApi`. This makes it possible to call **new** or **existing** endpoints previously not suppported via this library's Typed API.

See Usage > [**Type-less API**](README.md#type-less-api) below for details.


## How to Install  
From Nuget
```
Install-Package PayStack.Net
```
# Usage
The most important type in this library is the **[PayStackApi](https://github.com/adebisi-fa/paystack-dotnet/blob/master/src/main/PayStackApi.cs)** class.  This can be created as follows:
```c#
var testOrLiveSecret = ConfigurationManager.AppSettings["PayStackSecret"];
var api = new PayStackApi(testOrLiveSecret);
```
To enhance discovery, all types are exposed under the **PayStack.Net** namespace. So, remember to include:
```c#
...
using PayStack.Net;
...
```

As implemented from version 1.0.0 and later, this library exposes [Paystack APIs](https://paystack.com/docs/api) in two major ways:
1. Typed: Intellisense and support for most commonly used APIs; and
2. Type-less: No intellisense (by default), but with 100% API coverage.

## Typed API
---
Please see usage examples (and instructions) below:

### Transactions API
To consume the Transactions API, use methods from the **[ITransactionsApi](https://github.com/adebisi-fa/paystack-dotnet/blob/master/src/main/Apis/Transactions/ITransactionsApi.cs)** interface (available via the **Transactions** property of **PayStackApi**, viz:
```c#

// Initializing a transaction
var response = api.Transactions.Initialize("user@somewhere.net", 5000000);
if (response.Status)
  // use response.Data
else
  // show response.Message
  
// Verifying a transaction
var verifyResponse = api.Transactions.Verify("transaction-reference"); // auto or supplied when initializing;
if (verifyResponse.Status)
  /* 
      You can save the details from the json object returned above so that the authorization code 
      can be used for charging subsequent transactions
      
      // var authCode = verifyResponse.Data.Authorization.AuthorizationCode
      // Save 'authCode' for future charges!
  */
```

The **ITransactionsApi** is defined as follows:
```c#
public interface ITransactionsApi
{
    TransactionInitializeResponse Initialize(string email, int amount);
    TransactionInitializeResponse Initialize(TransactionInitializeRequest request);
    TransactionVerifyResponse Verify(string reference);
    TransactionListResponse List(TransactionListRequest request = null);
    TransactionFetchResponse Fetch(string transactionId);
    TransactionTimelineResponse Timeline(string transactionIdOrReference);
    TransactionTotalsResponse Totals(DateTime? from = null, DateTime? to = null);

    TransactionExportResponse Export(DateTime? from = null, DateTime? to = null,
        bool settled = false, string paymentPage = null);
}
```

### Other APIs
---

Other APIs are implemented in like manner and exposed via the **PayStackApi** type as given below:
```c#
// Customer APIs

var request = new CustomerCreateRequest { ... };
var response = api.Customers.Create(request);

var listRequest = new CustomerListRequest { ... };
var listResponse = api.Customers.List(listRequest);  // api.Customers is of type ICustomersApi 

// Sub Accounts APIs

var saRequest = new SubAccountCreateRequest { ... };
var response = api.SubAccounts.Create(saRequest); // api.SubAccounts is of type ISubAccountsApi
// response.Status, response.Message, response.Data are available

// etc
```

The only exception to this is the API for resolving a card's identity given its Bank Identification Number (BIN), **[ResolveCardBin("...")](https://github.com/adebisi-fa/paystack-dotnet/blob/master/src/main/PayStackApi.cs#L49)**, which is defined directly on the **PayStackApi** class, as follows:

```c#
ResolveCardBinResponse response = api.ResolveCardBin("123456");
// Use response as necessary
```

## Type-less API (available since v1.0.0)
---
The `Get`, `Post`, and `Put` methods on `PayStackApi` allow for `Type-less` access to the entire PayStack API (100% coverage! Albeit without intellisense, by default).

For example, the `InitializePayment` endpoint can be called via the Type-less API, viz:

```c#
var _api = new PayStackApi(...);

var result = _api
  .Post<ApiResponse<dynamic>, dynamic>(
    "/transaction/initialize", 
    new {
      amount = 5000000, // N50,000.00,
      email = "someone@somewhere.net",
      currency = "NGN",
      reference = "",
    }
  );

if (result.Status) { 
  // use result.Data.authorization_url
  // Note: result.Data properties appear as presented in API docs.
} 
else { 
  // display result.Message 
}

```

Intellisense can be enabled for the Type-less API by creating a custom `Response` class that matches the `.data` schema of the API being called.

For example, the following snippet will enable intellisense for the `InitializePayment` Type-less API:

```c#
// defined a .data schema compatible class
public class DtoInitializePayment {
    public string authorization_url { get; set; }
    public string reference { get; set; }
    public string access_code { get; set; }
}
```
or with .Net naming convention

```c#
// define a result.data schema compatible class
public class DtoInitializePayment {
    [JsonProperty("authorization_url")]
    public string AuthorizationUrl { get; set; }

    public string Reference { get; set; }

    [JsonProperty("access_code")]
    public string AccessCode { get; set; }
}
```

The DTO class can then be used when calling Type-less API, viz:

```c#
var _api = new PayStackApi(...);

var result = _api
  .Post<ApiResponse<DtoInitializePayment>, dynamic>(
    "/transaction/initialize", 
    new {
      amount = 5000000, // N50,000.00,
      email = "someone@somewhere.net",
      currency = "NGN",
      reference = "",
    }
  );

if (result.Status) { 
  // Use result as follows (with properties available via intellisense!):
  // result.Data.authorization_url; or
  // result.Data.AuthorizationUrl 
  // ...depending on the Dto class used.

} 
else { 
  // display result.Message 
}

```


## Working with Metadata
Some PayStack API allow sending additional information about your request via an optional **metadata** property.  PayStack.Net **Request Types** that support this feature (e.g. **[TransactionInitializeRequest](https://github.com/adebisi-fa/paystack-dotnet/blob/master/src/main/Apis/Transactions/Initialize.cs#L6)**, **[SubAccountCreateRequest](https://github.com/adebisi-fa/paystack-dotnet/blob/master/src/main/Apis/SubAccounts/Create.cs#L81)**, **[ChargeAuthorizationRequest](https://github.com/adebisi-fa/paystack-dotnet/blob/master/src/main/Apis/Transactions/ChargeAuthorization.cs#L6)**, among others) inherit from the **[RequestMetadataExtender](https://github.com/adebisi-fa/paystack-dotnet/blob/master/src/main/Apis/RequestMetadataExtender.cs)** class.  RequestMetadataExtender class has two properties, **CustomFields** (a List of **[CustomField](https://github.com/adebisi-fa/paystack-dotnet/blob/master/src/main/Apis/RequestMetadataExtender.cs#L35)**) and **MetadataObject** (a **string**-keyed dictionary of **object**), and can be used thus:
```c#
// Prepare request object and set necessary payload on request
var request = new TransactionInitializeRequest { ... };

// Add a custom-field to metadata
request.CustomFields.Add(
  CustomField.From("Field Name", "field_variable_name", "Field Value")
);

//  Send request
var response = api.Transactions.Initialize(request);

// Use response as needed
...
```
Arbitary non custom-field metadata can be set, viz:
```c#
// Prepare request object and set necessary payload on request
var request = new SubAccountCreateRequest { ... };

// Add arbitary information to metadata
request.MetadataObject["Technical-Tip"] = "Microservices are awesome with Docker & Kubernetes!";
request.MetadataObject["ProductionUrl"] = "http://amazon.co.uk/product-url-slugified";

// Send request
var response = api.SubAccounts.Create(request);

// Use response as needed
...
```

## One more thing about `~Response` Types (since v0.7.2)!

For situations where some properties (`data.[property1][property2][...n]`) are not directly exposed via the Typed Interface implemented by this library, all PayStack.Net `~Response` types expose the `.RawJson` property that contains the raw JSON content returned from the PayStack Server, as a `String`.

As a `String`, this value can be parsed using any .Net compatible JSON parser, for use.

However, to make it easier to work this raw JSON (especially to remove the need for extra parsing before use), all `~Response` types has an extension method, `.AsJObject()`, which returns a `JObject` instance.  With this object, any property of the returned JSON can be retrieved as described on [this page](https://www.newtonsoft.com/json/help/html/QueryingLINQtoJSON.htm). 


### `~Response` Enhancement (since v1.1.3)
To ease parsing the `.RawJson` property, all `~Response` types expose the following generic extension methods: `.As<T>()` (alias `.ToObject<T>()`), `.DataAs<T>`, and (alias `.DataToObject<T>()`). These can be used as follows:

```c#
// Types
class Bank
{
    public string name { get; set; }

    // will match json 'code' property, not case sensitive.
    public string coDe { get; set; }

    [JsonProperty("slug")]
    public string BankSlug { get; set; }
}

class CustomListBankResponse
{
    public bool Status { get; set; }
    public string message { get; set; } // Not case sensitive
    public IList<Bank> data { get; set; }
}

// METHOD 1: With Typed Response
Console.WriteLine("Method 1:");
var response = _api.Miscellaneous.ListBanks();
foreach (var b in response.Data.Take(2)) // First two(2) banks
    Console.WriteLine($"[{b.Code}] {b.Name} {b.Slug}");
Console.WriteLine("Status: {0}", response.Status); // should be "True"
Console.WriteLine();

// METHOD 2: With Custom Types or dynamic

// Example 1: Parse the response's data to a custom list of Banks
Console.WriteLine("Method 2.1: Response's data parsing");
var banks = response.DataAs<IList<Bank>>();
foreach (var b in banks.Take(2)) // First two(2) banks.
    Console.WriteLine($"[{b.coDe}] {b.name} {b.BankSlug}");
Console.WriteLine();

// Example 2: Parse the full response to a custom type
Console.WriteLine("Method 2.2: Full response parsing via Custom Type.");
var customResponse = response.As<CustomListBankResponse>();
foreach (var b in customResponse.data.Take(2)) // First two(2) banks.
    Console.WriteLine($"[{b.coDe}] {b.name} {b.BankSlug}");
Console.WriteLine("Status: {0}", customResponse.Status); // should be "True"
Console.WriteLine();

// Example 3: Parse the full response json to a dynamic
Console.WriteLine("Method 2.3: Full response parsing via dynamic");
var customResponseDynamic = response.As<dynamic>();
var firstTwoBanks = ((IEnumerable<dynamic>)customResponseDynamic.data).Take(2); // First two(2) banks.
foreach (var b in firstTwoBanks)
    // For dynamic, properties (including nested) must be used as it appeared in the raw json
    Console.WriteLine($"[{b.code}] {b.name} {b.slug}");
Console.WriteLine("Status: {0}", customResponseDynamic.status); // should be "True"
Console.WriteLine();

/* Output
~/src/test-console$ dotnet run

Method 1:
[120001] 9mobile 9Payment Service Bank 9mobile-9payment-service-bank-ng
[404] Abbey Mortgage Bank abbey-mortgage-bank-ng
Status: True

Method 2.1: Response's data parsing
[120001] 9mobile 9Payment Service Bank 9mobile-9payment-service-bank-ng
[404] Abbey Mortgage Bank abbey-mortgage-bank-ng

Method 2.2: Full response parsing via Custom Type.
[120001] 9mobile 9Payment Service Bank 9mobile-9payment-service-bank-ng
[404] Abbey Mortgage Bank abbey-mortgage-bank-ng
Status: True

Method 2.3: Full response parsing via dynamic
[120001] 9mobile 9Payment Service Bank 9mobile-9payment-service-bank-ng
[404] Abbey Mortgage Bank abbey-mortgage-bank-ng
Status: True

*/

```

