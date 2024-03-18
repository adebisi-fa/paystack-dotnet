using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PayStack.Net
{
    public class ListBanks
    {
        public class Datum
        {

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("slug")]
            public string Slug { get; set; }

            [JsonProperty("code")]
            public string Code { get; set; }

            [JsonProperty("longcode")]
            public string Longcode { get; set; }

            [JsonProperty("gateway")]
            public string Gateway { get; set; }

            [JsonProperty("active")]
            public bool Active { get; set; }

            [JsonProperty("is_deleted")]
            public object IsDeleted { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }
        }
    }

    public class ListBanksResponse : HasRawResponse, IApiResponse
    {

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public IList<ListBanks.Datum> Data { get; set; }
    }
}
