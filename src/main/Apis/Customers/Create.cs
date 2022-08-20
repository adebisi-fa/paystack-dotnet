using System;
using Newtonsoft.Json;

namespace PayStack.Net
{
    public class CustomerCreate
    {
        public class Data
        {
            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("integration")]
            public int Integration { get; set; }

            [JsonProperty("domain")]
            public string Domain { get; set; }

            [JsonProperty("customer_code")]
            public string CustomerCode { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }
        }
    }

    public class CustomerCreateRequest : RequestMetadataExtender
    {
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        public string Phone { get; set; }
    }

    public class CustomerCreateResponse : HasRawResponse, IApiResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public CustomerCreate.Data Data { get; set; }
    }
}