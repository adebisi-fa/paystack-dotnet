using Newtonsoft.Json;

namespace PayStack.Net
{
    public class CustomerFetchResponse  : HasRawResponse, IApiResponse
    {

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public CustomerList.Datum Data { get; set; }
    }
}
