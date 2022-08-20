using System;

namespace PayStack.Net
{
    public interface ITransactionsApi
    {
        TransactionInitializeResponse Initialize(string email, int amountInKobo, string reference = null, bool makeReferenceUnique = false, string currency = "NGN", string splitCode = null);
        TransactionInitializeResponse Initialize(TransactionInitializeRequest request, bool makeReferenceUnique = false);
        TransactionVerifyResponse Verify(string reference);
        TransactionListResponse List(TransactionListRequest request = null);
        TransactionFetchResponse Fetch(string transactionId);
        TransactionTimelineResponse Timeline(string transactionIdOrReference);
        TransactionTotalsResponse Totals(DateTime? from = null, DateTime? to = null);
        ChargeAuthorizationResponse ChargeAuthorization(string authorizationCode, string email, int amountInKobo, string reference = null, bool makeReferenceUnique = false);
        ChargeAuthorizationResponse ChargeAuthorization(ChargeAuthorizationRequest request, bool makeReferenceUnique = false);
        TransactionExportResponse Export(DateTime? from = null, DateTime? to = null,
            bool settled = false, string paymentPage = null);
        ReAuthorizationResponse RequestReAuthorization(string authorizationCode, string email, int amountInKobo, string reference = null, bool makeReferenceUnique = false);
        ReAuthorizationResponse RequestReAuthorization(ReAuthorizationRequest request, bool makeReferenceUnique = false);

        CheckAuthorizationResponse CheckAuthorization(string authorizationCode, string email, int amountInKobo);
        CheckAuthorizationResponse CheckAuthorization(CheckAuthorizationRequest request);
        TransactionPartialDebitResponse PartialDebit(TransactionPartialDebitRequest request);
        TransactionPartialDebitResponse PartialDebit(string authorizationCode, string currency, string amount, string email);
    }
}