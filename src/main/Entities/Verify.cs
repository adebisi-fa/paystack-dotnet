using System;
using Newtonsoft.Json;

namespace PayStack.Net
{
    public class VerifyRequest
    {
        public string Reference { get; set; }
    }

    public class VerifyResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public VerifyResponseData Data { get; set; }
    }

    public class VerifyResponseData
    {
        public long Amount { get; set; }

        [JsonProperty("transaction_date")]
        public DateTime TransactionDate { get; set; }

        public string Success { get; set; }
        public string Reference { get; set; }
        public string Domain { get; set; }
        public VerifyResponseAuthorization Authorization { get; set; }
        public VerifyResponseCustomer Customer { get; set; }
        public string Plan { get; set; }
    }

    public class VerifyResponseAuthorization
    {
        [JsonProperty("authorization_code")]
        public string Code { get; set; }

        [JsonProperty("card_type")]
        public string CardType { get; set; }

        [JsonProperty("last4")]
        public string Last4Digits { get; set; }

        public string Bank { get; set; }
    }

    public class VerifyResponseCustomer
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        public string Email { get; set; }
    }
}