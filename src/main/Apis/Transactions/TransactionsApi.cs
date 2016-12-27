using System;
using XtremeIT.Library.Pins;

namespace PayStack.Net
{
    internal class TransactionsApi : ITransactionsApi
    {
        private readonly PayStackApi _api;

        internal TransactionsApi(PayStackApi api)
        {
            _api = api;
        }

        public TransactionInitializeResponse Initialize(string email, int amount, string reference = null, bool makeReferenceUnique = false)
            => Initialize(new TransactionInitializeRequest { Reference = reference, Email = email, AmountInKobo = amount }, makeReferenceUnique);

        public TransactionInitializeResponse Initialize(TransactionInitializeRequest request, bool makeReferenceUnique = false)
        {
            if (makeReferenceUnique)
                request.Reference = $"{request.Reference}-{Generator.NewPin(new GeneratorSettings { Domain = GeneratorCharacterDomains.AlphaNumerics, PinLength = 7 })}";
            return _api.Post<TransactionInitializeResponse, TransactionInitializeRequest>("transaction/initialize", request);
        }


        public TransactionVerifyResponse Verify(string reference) =>
                _api.Get<TransactionVerifyResponse>($"transaction/verify/{reference}");

        public TransactionListResponse List(TransactionListRequest request = null) =>
            _api.Get<TransactionListResponse, TransactionListRequest>("transaction", request);

        public TransactionFetchResponse Fetch(string transactionId) =>
            _api.Get<TransactionFetchResponse>($"transaction/{transactionId}");

        public TransactionTimelineResponse Timeline(string transactionIdOrReference) =>
            _api.Get<TransactionTimelineResponse>($"transaction/timeline/{transactionIdOrReference}");

        public TransactionTotalsResponse Totals(DateTime? from = null, DateTime? to = null) =>
            _api.Get<TransactionTotalsResponse, TransactionTotalsRequest>(
                "transaction/totals", new TransactionTotalsRequest { From = from, To = to }
            );

        public TransactionExportResponse Export(DateTime? from = null, DateTime? to = null,
            bool settled = false, string paymentPage = null) =>
            _api.Get<TransactionExportResponse, TransactionExportRequest>(
                "transaction/export",
                new TransactionExportRequest { From = from, To = to, Settled = settled, PaymentPage = paymentPage }
            );
    }
}