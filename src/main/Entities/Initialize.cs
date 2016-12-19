using Newtonsoft.Json;

namespace PayStack.Net
{
    public class InitializeRequest
    {
        public string Reference { get; set; }

        [JsonProperty("amount")]
        public string AmountInKobo { get; set; }

        public string Email { get; set; }
        public string Plan { get; set; }

        [JsonProperty("callback_url")]
        public string CallbackUrl { get; set; }

        public string SubAccount { get; set; }

        [JsonProperty("transaction_charge")]
        public int TransactionCharge { get; set; }

        public string Bearer { get; set; }
    }

    public class InitializeResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public InitializeResponseData Data { get; set; }
    }

    public class InitializeResponseData
    {
        [JsonProperty("authorization_url")]
        public string AuthorizationUrl { get; set; }

        [JsonProperty("access_code")]
        public string AccessCode { get; set; }

        public string Reference { get; set; }
    }
}