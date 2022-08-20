using System;
using Newtonsoft.Json;

namespace PayStack.Net
{
    public class ChargeTokenize
    {
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

            [JsonProperty("signature")]
            public string Signature { get; set; }

            [JsonProperty("reusable")]
            public bool Reusable { get; set; }

            [JsonProperty("country_code")]
            public string CountryCode { get; set; }

            [JsonProperty("customer")]
            public Customer Customer { get; set; }
        }
    }

    public class ChargeTokenizeResponse : HasRawResponse, IApiResponse
    {

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ChargeTokenize.Data Data { get; set; }
    }
}