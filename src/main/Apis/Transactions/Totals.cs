using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PayStack.Net
{
    public class TransactionTotals
    {
        public class TotalVolumeByCurrency
        {
            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("amount")]
            public int Amount { get; set; }
        }

        public class PendingTransfersByCurrency
        {
            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("amount")]
            public int Amount { get; set; }
        }

        public class Data
        {
            [JsonProperty("total_transactions")]
            public int TotalTransactions { get; set; }

            [JsonProperty("unique_customers")]
            public int UniqueCustomers { get; set; }

            [JsonProperty("total_volume")]
            public int TotalVolume { get; set; }

            [JsonProperty("total_volume_by_currency")]
            public IList<TotalVolumeByCurrency> TotalVolumeByCurrencyCollection { get; set; }

            [JsonProperty("pending_transfers")]
            public int PendingTransfers { get; set; }

            [JsonProperty("pending_transfers_by_currency")]
            public IList<PendingTransfersByCurrency> PendingTransfersByCurrencyCollection { get; set; }
        }
    }

    public class TransactionTotalsRequest
    {
        public int PerPage { get; set; } = 50;
        public int Page { get; set; } = 1;
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }

    public class TransactionTotalsResponse : HasRawResponse, IApiResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public TransactionTotals.Data Data { get; set; }
    }
}