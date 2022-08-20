using Newtonsoft.Json;

namespace PayStack.Net
{
    public class ResolveAcountNumber
    {
        public class Data
        {

            [JsonProperty("account_number")]
            public string AccountNumber { get; set; }

            [JsonProperty("account_name")]
            public string AccountName { get; set; }
        }
    }

    public class ResolveAccountNumberResponse : HasRawResponse, IApiResponse
    {

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ResolveAcountNumber.Data Data { get; set; }
    }

}