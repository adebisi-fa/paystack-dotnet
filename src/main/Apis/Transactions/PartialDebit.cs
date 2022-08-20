using System;
using Newtonsoft.Json;

namespace PayStack.Net
{
    public class TransactionPartialDebit
    {
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

            [JsonProperty("channel")]
            public string Channel { get; set; }

            [JsonProperty("card_type")]
            public string CardType { get; set; }

            [JsonProperty("bank")]
            public string Bank { get; set; }

            [JsonProperty("country_code")]
            public string CountryCode { get; set; }

            [JsonProperty("brand")]
            public string Brand { get; set; }

            [JsonProperty("reusable")]
            public bool Reusable { get; set; }

            [JsonProperty("signature")]
            public string Signature { get; set; }

            [JsonProperty("account_name")]
            public string AccountName { get; set; }
        }

        public class Customer
        {

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("first_name")]
            public string FirstName { get; set; }

            [JsonProperty("last_name")]
            public string LastName { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("customer_code")]
            public string CustomerCode { get; set; }

            [JsonProperty("phone")]
            public string Phone { get; set; }

            [JsonProperty("metadata")]
            public object Metadata { get; set; }

            [JsonProperty("risk_action")]
            public string RiskAction { get; set; }
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
            public string Metadata { get; set; }

            [JsonProperty("gateway_response")]
            public string GatewayResponse { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("channel")]
            public string Channel { get; set; }

            [JsonProperty("ip_address")]
            public string IpAddress { get; set; }

            [JsonProperty("log")]
            public dynamic Log { get; set; }

            [JsonProperty("fees")]
            public int Fees { get; set; }

            [JsonProperty("authorization")]
            public Authorization Authorization { get; set; }

            [JsonProperty("customer")]
            public Customer Customer { get; set; }

            [JsonProperty("plan")]
            public int Plan { get; set; }
        }

    }

    public class TransactionPartialDebitRequest
    {

        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("at_least")]
        public string AtLeast { get; set; }
    }

    public class TransactionPartialDebitResponse : HasRawResponse, IApiResponse
    {

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public TransactionPartialDebit.Data Data { get; set; }
    }

}