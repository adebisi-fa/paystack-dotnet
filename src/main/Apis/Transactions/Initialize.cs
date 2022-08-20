using Newtonsoft.Json;

namespace PayStack.Net
{
    public class TransactionInitializeRequest : RequestMetadataExtender
    {
        public string Reference { get; set; }

        [JsonProperty("amount")]
        public int AmountInKobo { get; set; }

        public string Email { get; set; }

        public string Plan { get; set; }

        [JsonProperty("callback_url")]
        public string CallbackUrl { get; set; }

        [JsonProperty("subaccount")]
        public string SubAccount { get; set; }

        [JsonProperty("transaction_charge")]
        public int TransactionCharge { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; } = "NGN";

        public string Bearer { get; set; }

        [JsonProperty("invoice_limit")]
        public int? InvoiceLimit { get; set; }

        public string[] Channels { get; set; }

        [JsonProperty("split_code")]
        public string SplitCode { get; set; }
    }

    public static class PayStackChargesBearer
    {
        public static string Account = nameof(Account).ToLower();
        public static string SubAccount = nameof(SubAccount).ToLower();
    }

    public class TransactionInitialize
    {
        public class Data
        {
            [JsonProperty("authorization_url")]
            public string AuthorizationUrl { get; set; }

            [JsonProperty("access_code")]
            public string AccessCode { get; set; }

            [JsonProperty("reference")]
            public string Reference { get; set; }
        }
    }

    public class TransactionInitializeResponse : HasRawResponse, IApiResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public TransactionInitialize.Data Data { get; set; }
    }
}