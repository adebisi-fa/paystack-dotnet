using Newtonsoft.Json;

namespace PayStack.Net
{
    public class CheckAuthorizationRequest
    {

        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }

        public string Currency { get; set; }

        [JsonProperty("amount")]
        public int AmountInKobo { get; set; }

        public string Email { get; set; }

    }

    public class CheckAuthorizationResponse : HasRawResponse, IApiResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public CheckAuthorizationData Data { get; set; }
    }

    public class CheckAuthorizationData
    {
        [JsonProperty("amount")]
        public string AmountInKobo { get; set; }
        public string Currency { get; set; }
    }
}