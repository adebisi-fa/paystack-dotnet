using Newtonsoft.Json;

namespace PayStack.Net
{
    public class ResolveBVN
    {
        public class Data
        {
            [JsonProperty("first_name")]
            public string FirstName { get; set; }

            [JsonProperty("last_name")]
            public string LastName { get; set; }

            [JsonProperty("dob")]
            public string Dob { get; set; }

            [JsonProperty("mobile")]
            public string Mobile { get; set; }

            [JsonProperty("bvn")]
            public string Bvn { get; set; }
        }

        public class Meta
        {

            [JsonProperty("calls_this_month")]
            public int CallsThisMonth { get; set; }

            [JsonProperty("free_calls_left")]
            public int FreeCallsLeft { get; set; }
        }
    }

    public class ResolveBVNResponse : HasRawResponse, IApiResponse
    {

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ResolveBVN.Data Data { get; set; }

        [JsonProperty("meta")]
        public ResolveBVN.Meta Meta { get; set; }
    }
}