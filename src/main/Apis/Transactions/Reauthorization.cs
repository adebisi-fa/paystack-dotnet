using Newtonsoft.Json;

namespace PayStack.Net
{
    public class ReAuthorizationRequest : RequestMetadataExtender
    {
        public string Reference { get; set; }

        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }

        public string Currency { get; set; }

        [JsonProperty("amount")]
        public int AmountInKobo { get; set; }

        public string Email { get; set; }
    }

    public class ReAuthorizationResponse : HasRawResponse, IApiResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ReAuthorizationData Data { get; set; }
    }

    public class ReAuthorizationData {
        [JsonProperty("reauthorization_url")]
        public string ReAuthorizationUrl { get; set; }

        public string Reference { get; set; }
    }
}