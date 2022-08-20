using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PayStack.Net
{
    public class ListTransfers
    {
        public class Datum
        {

            [JsonProperty("integration")]
            public int Integration { get; set; }

            [JsonProperty("recipient")]
            public TransferRecipient.Data Recipient { get; set; }

            [JsonProperty("domain")]
            public string Domain { get; set; }

            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("source")]
            public string Source { get; set; }

            [JsonProperty("source_details")]
            public object SourceDetails { get; set; }

            [JsonProperty("reason")]
            public string Reason { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("failures")]
            public object Failures { get; set; }

            [JsonProperty("transfer_code")]
            public string TransferCode { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }
        }

        public class Meta
        {

            [JsonProperty("total")]
            public int Total { get; set; }

            [JsonProperty("skipped")]
            public int Skipped { get; set; }

            [JsonProperty("perPage")]
            public int PerPage { get; set; }

            [JsonProperty("page")]
            public int Page { get; set; }

            [JsonProperty("pageCount")]
            public int PageCount { get; set; }
        }
    }

    public class ListTransfersResponse : HasRawResponse, IApiResponse
    {

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public IList<ListTransfers.Datum> Data { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}