using System.Collections.Generic;
using Newtonsoft.Json;

namespace PayStack.Net
{
    public class CustomerUpdateRequest
    {
        public CustomerUpdateRequest()
        {
            Metadata = new Dictionary<string, object>();
        }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        public string Phone { get; set; }

        public Dictionary<string, object> Metadata { get; set; }
    }

    public class CustomerUpdateResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public CustomerList.Datum Data { get; set; }
    }
}