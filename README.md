# PayStack API for .Net
This library makes it easy to consume the [Payment API](http://developers.paystack.co/docs) from .Net projects.

## How to Install  
From Nuget
```
Install-Package PayStack.Net
```
# Usage
The most important class in this library is the **[PayStackApi](https://github.com/adebisi-fa/paystack-dotnet/blob/master/src/main/PayStackApi.cs)** class.  This can be created as follows:
```c#
var testOrLiveSecret = ConfigurationManager.AppSettings["PayStackSecret"];
var api = new PayStackApi(testOrLiveSecret);
```

## Transactions API
To consume the Transactions API, use methods from the **[ITransactionsApi](https://github.com/adebisi-fa/paystack-dotnet/blob/master/src/main/Apis/Transactions/ITransactionsApi.cs)** interface (available via the **Transactions** property of **PayStackApi**, viz:
```c#
TransactionInitializationResponse response = api.Transactions.Initialize("user@somewhere.net", "5000000");
if (response.Status)
  // use response.Data
else
  // show response.Message
```

The **ITransactionsApi** is defined as follows:
```c#
public interface ITransactionsApi
{
    TransactionInitializeResponse Initialize(string email, string amount);
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
