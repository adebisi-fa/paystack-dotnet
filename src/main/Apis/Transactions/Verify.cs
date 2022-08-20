using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PayStack.Net
{
    public class TransactionVerify
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

            [JsonProperty("card_type")]
            public string CardType { get; set; }

            [JsonProperty("last4")]
            public string Last4 { get; set; }

            [JsonProperty("exp_month")]
            public string ExpMonth { get; set; }

            [JsonProperty("exp_year")]
            public string ExpYear { get; set; }

            [JsonProperty("bin")]
            public string Bin { get; set; }

            [JsonProperty("bank")]
            public string Bank { get; set; }

            [JsonProperty("channel")]
            public string Channel { get; set; }

            [JsonProperty("reusable")]
            public bool? Reusable { get; set; }

            [JsonProperty("country_code")]
            public string CountryCode { get; set; }
        }

        public class Customer
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("customer_code")]
            public string CustomerCode { get; set; }

            [JsonProperty("first_name")]
            public string FirstName { get; set; }

            [JsonProperty("last_name")]
            public string LastName { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }
        }

        public class Data
        {
            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("transaction_date")]
            public DateTime TransactionDate { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("reference")]
            public string Reference { get; set; }

            [JsonProperty("domain")]
            public string Domain { get; set; }

            [JsonProperty("metadata")]
            public Metadata Metadata { get; set; }

            [JsonProperty("gateway_response")]
            public string GatewayResponse { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("channel")]
            public string Channel { get; set; }

            [JsonProperty("ip_address")]
            public string IpAddress { get; set; }

            [JsonProperty("log")]
            public Log Log { get; set; }

            [JsonProperty("fees")]
            public object Fees { get; set; }

            [JsonProperty("authorization")]
            public Authorization Authorization { get; set; }

            [JsonProperty("customer")]
            public Customer Customer { get; set; }

            [JsonProperty("plan")]
            public string Plan { get; set; }
        }
    }

    public class TransactionVerifyResponse : HasRawResponse, IApiResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public TransactionVerify.Data Data { get; set; }
    }
}