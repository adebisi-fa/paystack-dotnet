using System;

namespace PayStack.Net
{
    internal class TransactionsApi : ITransactionsApi
    {
        private readonly PayStackApi _api;

        internal TransactionsApi(PayStackApi api)
        {
            _api = api;
        }

        public TransactionInitializeResponse Initialize(
            string email,
            int amount,
            string reference = null,
            bool makeReferenceUnique = false,
            string currency = "NGN",
            string splitCode = null
        ) =>
            Initialize(
                new TransactionInitializeRequest
                {
                    Reference = reference,
                    Email = email,
                    AmountInKobo = amount,
                    Currency = currency,
                    SplitCode = splitCode,
                },
                makeReferenceUnique
            );

        public TransactionInitializeResponse Initialize(
            TransactionInitializeRequest request,
            bool makeReferenceUnique = false
        )
        {
            if (makeReferenceUnique && request.Reference != null)
                request.Reference =
                    $"{request.Reference}-{Guid.NewGuid().ToString().Substring(0, 8)}";
            return _api.Post<TransactionInitializeResponse, TransactionInitializeRequest>(
                "transaction/initialize",
                request
            );
        }

        public TransactionVerifyResponse Verify(string reference) =>
            _api.Get<TransactionVerifyResponse>($"transaction/verify/{reference}");

        public TransactionListResponse List(TransactionListRequest request = null) =>
            _api.Get<TransactionListResponse, TransactionListRequest>("transaction", request);

        public TransactionFetchResponse Fetch(string transactionId) =>
            _api.Get<TransactionFetchResponse>($"transaction/{transactionId}");

        public TransactionTimelineResponse Timeline(string transactionIdOrReference) =>
            _api.Get<TransactionTimelineResponse>(
                $"transaction/timeline/{transactionIdOrReference}"
            );

        public TransactionTotalsResponse Totals(DateTime? from = null, DateTime? to = null) =>
            _api.Get<TransactionTotalsResponse, TransactionTotalsRequest>(
                "transaction/totals",
                new TransactionTotalsRequest { From = from, To = to }
            );

        public TransactionExportResponse Export(
            DateTime? from = null,
            DateTime? to = null,
            bool settled = false,
            string paymentPage = null
        ) =>
            _api.Get<TransactionExportResponse, TransactionExportRequest>(
                "transaction/export",
                new TransactionExportRequest
                {
                    From = from,
                    To = to,
                    Settled = settled,
                    Payment_Page = paymentPage,
                }
            );

        public ChargeAuthorizationResponse ChargeAuthorization(
            string authorizationCode,
            string email,
            int amountInKobo,
            string reference = null,
            bool makeReferenceUnique = false
        ) =>
            ChargeAuthorization(
                new ChargeAuthorizationRequest
                {
                    Reference = reference,
                    AuthorizationCode = authorizationCode,
                    Email = email,
                    AmountInKobo = amountInKobo,
                },
                makeReferenceUnique
            );

        public ChargeAuthorizationResponse ChargeAuthorization(
            ChargeAuthorizationRequest request,
            bool makeReferenceUnique = false
        )
        {
            if (makeReferenceUnique && request.Reference != null)
                request.Reference =
                    $"{request.Reference}-{Guid.NewGuid().ToString().Substring(0, 8)}";
            return _api.Post<ChargeAuthorizationResponse, ChargeAuthorizationRequest>(
                "transaction/charge_authorization",
                request
            );
        }

        public ReAuthorizationResponse RequestReAuthorization(
            string authorizationCode,
            string email,
            int amountInKobo,
            string reference = null,
            bool makeReferenceUnique = false
        ) =>
            RequestReAuthorization(
                new ReAuthorizationRequest
                {
                    AuthorizationCode = authorizationCode,
                    Email = email,
                    AmountInKobo = amountInKobo,
                    Reference = reference,
                },
                makeReferenceUnique
            );

        public ReAuthorizationResponse RequestReAuthorization(
            ReAuthorizationRequest request,
            bool makeReferenceUnique = false
        )
        {
            if (makeReferenceUnique && request.Reference != null)
                request.Reference =
                    $"{request.Reference}-{Guid.NewGuid().ToString().Substring(0, 8)}";
            return _api.Post<ReAuthorizationResponse, ReAuthorizationRequest>(
                "transaction/request_reauthorization",
                request
            );
        }

        public CheckAuthorizationResponse CheckAuthorization(
            string authorizationCode,
            string email,
            int amountInKobo
        ) =>
            CheckAuthorization(
                new CheckAuthorizationRequest
                {
                    AuthorizationCode = authorizationCode,
                    Email = email,
                    AmountInKobo = amountInKobo,
                }
            );

        public CheckAuthorizationResponse CheckAuthorization(CheckAuthorizationRequest request) =>
            _api.Post<CheckAuthorizationResponse, CheckAuthorizationRequest>(
                "transaction/check_authorization",
                request
            );

        public TransactionPartialDebitResponse PartialDebit(
            TransactionPartialDebitRequest request
        ) =>
            _api.Post<TransactionPartialDebitResponse, TransactionPartialDebitRequest>(
                "transaction/partial_debit",
                request
            );

        public TransactionPartialDebitResponse PartialDebit(
            string authorizationCode,
            string currency,
            string amount,
            string email
        ) =>
            PartialDebit(
                new TransactionPartialDebitRequest
                {
                    AuthorizationCode = authorizationCode,
                    Amount = amount,
                    Currency = currency,
                    Email = email,
                }
            );
    }
}
