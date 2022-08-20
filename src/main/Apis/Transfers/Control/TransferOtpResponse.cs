using Newtonsoft.Json;

namespace PayStack.Net
{    
    public class TransferOtpResponse : HasRawResponse, IApiResponse
    {

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}