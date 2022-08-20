using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PayStack.Net
{
    public class SettlementsFetch
    {
        public class Datum
        {
            [JsonProperty("integration")]
            public int Integration { get; set; }

            [JsonProperty("subaccount")]
            public SubAccountList.Datum SubAccount { get; set; }

            [JsonProperty("settled_by")]
            public string SettledBy { get; set; }

            [JsonProperty("settlement_date")]
            public DateTime SettlementDate { get; set; }

            [JsonProperty("domain")]
            public string Domain { get; set; }

            [JsonProperty("total_amount")]
            public int TotalAmount { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime? UpdatedAt { get; set; }
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

    public class SettlementsFetchRequest
    {
        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        [JsonProperty("subaccount")]
        public string SubAccount { get; set; } = "none";
    }

    public class SettlementsFetchResponse : HasRawResponse, IApiResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public IList<SettlementsFetch.Datum> Data { get; set; }

        [JsonProperty("meta")]
        public SettlementsFetch.Meta Meta { get; set; }
    }
}