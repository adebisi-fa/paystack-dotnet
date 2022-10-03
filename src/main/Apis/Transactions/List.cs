using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PayStack.Net
{
    public class TransactionList
    {
        public class History
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("time")]
            public int Time { get; set; }
        }

        public class Log
        {
            [JsonProperty("time_spent")]
            public int TimeSpent { get; set; }

            [JsonProperty("attempts")]
            public int Attempts { get; set; }

            [JsonProperty("authentication")]
            public object Authentication { get; set; }

            [JsonProperty("errors")]
            public int Errors { get; set; }

            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("mobile")]
            public bool Mobile { get; set; }

            [JsonProperty("input")]
            public IList<object> Input { get; set; }

            [JsonProperty("channel")]
            public object Channel { get; set; }

            [JsonProperty("history")]
            public IList<History> Histories { get; set; }
        }

        public class Authorization
        {
            [JsonProperty("authorization_code")]
            public string AuthorizationCode { get; set; }

            [JsonProperty("bin")]
            public string Bin { get; set; }

            [JsonProperty("last4")]
            public string Last4 { get; set; }

            [JsonProperty("exp_month")]
            public string ExpMonth { get; set; }

            [JsonProperty("exp_year")]
            public string ExpYear { get; set; }

            [JsonProperty("card_type")]
            public string CardType { get; set; }

            [JsonProperty("bank")]
            public string Bank { get; set; }

            [JsonProperty("country_code")]
            public string CountryCode { get; set; }

            [JsonProperty("reusable")]
            public bool? Reusable { get; set; }

            [JsonProperty("brand")]
            public string Brand { get; set; }

            [JsonProperty("channel")]
            public string Channel { get; set; }
        }

        public class Customer
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("customer_code")]
            public string CustomerCode { get; set; }

            [JsonProperty("risk_action")]
            public string RiskAction { get; set; }
        }

        public class Datum
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("domain")]
            public string Domain { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("reference")]
            public string Reference { get; set; }

            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("gateway_response")]
            public string GatewayResponse { get; set; }

            [JsonProperty("paid_at")]
            public DateTime? PaidAt { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("channel")]
            public string Channel { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("ip_address")]
            public string IpAddress { get; set; }

            [JsonProperty("metadata")]
            public Metadata Metadata { get; set; }

            [JsonProperty("log")]
            public Log Log { get; set; }

            [JsonProperty("fees")]
            public string Fees { get; set; }

            [JsonProperty("paidAt")]
            public DateTime? PaidAtRedundant { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAtRedundant { get; set; }

            [JsonProperty("authorization")]
            public Authorization Authorization { get; set; }

            [JsonProperty("customer")]
            public Customer Customer { get; set; }
        }

        public class Meta
        {
            [JsonProperty("total")]
            public int Total { get; set; }

            [JsonProperty("total_volume")]
            public int TotalVolume { get; set; }

            [JsonProperty("perPage")]
            public string PerPage { get; set; }

            [JsonProperty("page")]
            public int Page { get; set; }

            [JsonProperty("pageCount")]
            public int PageCount { get; set; }
        }
    }

    public class TransactionListRequest : IPreparable
    {
        public int PerPage { get; set; } = 50;
        public int Page { get; set; } = 1;
        public int Customer { get; set; }
        public string Status { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int Amount { get; set; }

        public void Prepare()
        {
            From = From.Date; // Start from 12:00 for this date
            To = To.Date; // Stops at 12:00 for this date
        }
    }

    public class TransactionListResponse : HasRawResponse, IApiResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public IList<TransactionList.Datum> Data { get; set; }

        [JsonProperty("meta")]
        public TransactionList.Meta Meta { get; set; }
    }
}