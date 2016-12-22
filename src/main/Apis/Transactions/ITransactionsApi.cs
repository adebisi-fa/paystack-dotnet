using System;
using PayStack.Net;

namespace PayStack.Net
{
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
}