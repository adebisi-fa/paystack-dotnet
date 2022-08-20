using Newtonsoft.Json;

namespace PayStack.Net
{
    public class FetchTransferResponse : HasRawResponse, IApiResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public Transfer Data { get; set; }
    }
}