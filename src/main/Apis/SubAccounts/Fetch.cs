using Newtonsoft.Json;

namespace PayStack.Net
{
    public class SubAccountFetchData : SubAccountCreate.Data
    {
    }

    public class SubAccountFetchResponse : HasRawResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public SubAccountFetchData Data { get; set; }
    }
}