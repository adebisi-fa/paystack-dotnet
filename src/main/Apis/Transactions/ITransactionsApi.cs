using System;

namespace PayStack.Net
{
    public interface ITransactionsApi
    {
        TransactionInitializeResponse Initialize(string email, int amount, string reference = null, bool makeReferenceUnique = false);
        TransactionInitializeResponse Initialize(TransactionInitializeRequest request, bool makeReferenceUnique = false);
        TransactionVerifyResponse Verify(string reference);
        TransactionListResponse List(TransactionListRequest request = null);
        TransactionFetchResponse Fetch(string transactionId);
        TransactionTimelineResponse Timeline(string transactionIdOrReference);
        TransactionTotalsResponse Totals(DateTime? from = null, DateTime? to = null);
        ChargeAuthorizationResponse ChargeAuthorization(string authorizationCode, string email, string amount);
        ChargeAuthorizationResponse ChargeAuthorization(ChargeAuthorizationRequest request);
        TransactionExportResponse Export(DateTime? from = null, DateTime? to = null,
            bool settled = false, string paymentPage = null);
    }
}